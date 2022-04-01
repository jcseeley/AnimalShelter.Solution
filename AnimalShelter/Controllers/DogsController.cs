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
  public class DogsController : ControllerBase
  {
    private readonly AnimalShelterContext _db;
    private readonly IUriService _uriService;

    public DogsController(AnimalShelterContext db, IUriService uriService)
    {
      _db = db;
      _uriService = uriService;
    }

    // GET api/animalshelter/dogs
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Dog>>> Get([FromQuery] PaginationFilter filter, string name, string gender, int age)
    {
      var route = Request.Path.Value;
      var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
      var query = _db.Dogs.AsQueryable();

      if (name != null)
      {
        query = query.Where(e => e.Name.Contains(name));
      }

      if (gender != null)
      {
        query = query.Where(e => e.Gender.Contains(gender));
      }

      if (age > 0)
      {
        query = query.Where(e => e.Age >= age);
      }

      var pagedData = await query
        .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
        .Take(validFilter.PageSize)
        .ToListAsync();
      var totalRecords = await _db.Dogs.CountAsync();
      var pagedResponse = PaginationHelper.CreatePagedReponse<Dog>(pagedData, validFilter, totalRecords, _uriService, route);
      return Ok(pagedResponse);
    }

    // POST api/animalshelter/dogs
    [HttpPost]
    public async Task<ActionResult<Dog>> Post(Dog dog)
    {
      _db.Dogs.Add(dog);
      await _db.SaveChangesAsync();

      return CreatedAtAction(nameof(GetDog), new { id = dog.DogId }, dog);
    }

    // GET: api/animalshelter/dogs/1
    [HttpGet("{id}")]
    public async Task<ActionResult<Dog>> GetDog(int id)
    {
      var dog = await _db.Dogs.FindAsync(id);

      if (dog == null)
      {
        return NotFound();
      }

      return Ok(new Response<Dog>(dog));
    }

    // PUT: api/animalshelter/dogs/1
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Dog dog)
    {
      if (id != dog.DogId)
      {
        return BadRequest();
      }

      _db.Entry(dog).State = EntityState.Modified;
      
      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!DogExists(id))
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

    // DELETE: api/animalshelter/dogs/1
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDog(int id)
    {
      var dog = await _db.Dogs.FindAsync(id);
      if (dog == null)
      {
        return NotFound();
      }

      _db.Dogs.Remove(dog);
      await _db.SaveChangesAsync();

      return NoContent();
    }
    private bool DogExists(int id)
    {
      return _db.Dogs.Any(e => e.DogId == id);
    }
  }
}