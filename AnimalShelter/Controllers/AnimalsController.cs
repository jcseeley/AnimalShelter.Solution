using AnimalShelter.Filters;
using AnimalShelter.Helpers;
using AnimalShelter.Models;
using AnimalShelter.Wrappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter.Controllers
{
  [Route("api/animalshelter/[controller]")]
  [ApiController]
  public class AnimalsController : ControllerBase
  {
    private readonly AnimalShelterContext _db;
    private readonly IUriService _uriService;

    public AnimalsController(AnimalShelterContext db, IUriService uriService)
    {
      _db = db;
      _uriService = uriService;
    }

    // GET api/animalshelter/animals
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Animal>>> Get([FromQuery] PaginationFilter filter, string type, string name, string gender, int maximumAge, int minimumAge)
    {
      var route = Request.Path.Value;
      var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
      var query = _db.Animals.AsQueryable();

      if (type != null)
      {
        query = query.Where(e => e.Type.Contains(type));
      }
      
      if (name != null)
      {
        query = query.Where(e => e.Name.Contains(name));
      }

      if (gender != null)
      {
        query = query.Where(e => e.Gender == gender);
      }

      if (maximumAge > 0)
      {
        query = query.Where(e => e.Age <= maximumAge);
      }

      if (minimumAge > 0)
      {
        query = query.Where(e => e.Age >= minimumAge);
      }

      var pagedData = await query
        .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
        .Take(validFilter.PageSize)
        .ToListAsync();
      var totalRecords = await _db.Animals.CountAsync();
      var pagedResponse = PaginationHelper.CreatePagedReponse<Animal>(pagedData, validFilter, totalRecords, _uriService, route);
      return Ok(pagedResponse);
    }

    // POST api/animalshelter/animals
    [HttpPost]
    public async Task<ActionResult<Animal>> Post(Animal animal)
    {
      _db.Animals.Add(animal);
      await _db.SaveChangesAsync();

      return CreatedAtAction(nameof(GetAnimal), new { id = animal.AnimalId }, animal);
    }

    // GET: api/animalshelter/animals/1
    [HttpGet("{id}")]
    public async Task<ActionResult<Animal>> GetAnimal(int id)
    {
      var animal = await _db.Animals.FindAsync(id);

      if (animal == null)
      {
        return NotFound();
      }

      return Ok(new Response<Animal>(animal));
    }

    // PUT: api/animalshelter/animals/1
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Animal animal)
    {
      if (id != animal.AnimalId)
      {
        return BadRequest();
      }

      _db.Entry(animal).State = EntityState.Modified;
      
      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!AnimalExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }

    // DELETE: api/animalshelter/animals/1
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAnimal(int id)
    {
      var animal = await _db.Animals.FindAsync(id);
      if (animal == null)
      {
        return NotFound();
      }

      _db.Animals.Remove(animal);
      await _db.SaveChangesAsync();

      return NoContent();
    }
    private bool AnimalExists(int id)
    {
      return _db.Animals.Any(e => e.AnimalId == id);
    }
  }
}