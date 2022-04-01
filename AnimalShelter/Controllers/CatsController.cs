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
  public class CatsController : ControllerBase
  {
    private readonly AnimalShelterContext _db;
    private readonly IUriService _uriService;

    public CatsController(AnimalShelterContext db, IUriService uriService)
    {
      _db = db;
      _uriService = uriService;
    }

    // GET api/animalshelter/cats
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Cat>>> Get([FromQuery] PaginationFilter filter, string name, string gender, int age)
    {
      var route = Request.Path.Value;
      var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
      var query = _db.Cats.AsQueryable();

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
      var totalRecords = await _db.Cats.CountAsync();
      var pagedResponse = PaginationHelper.CreatePagedReponse<Cat>(pagedData, validFilter, totalRecords, _uriService, route);
      return Ok(pagedResponse);
    }

    // POST api/animalshelter/cats
    [HttpPost]
    public async Task<ActionResult<Cat>> Post(Cat cat)
    {
      _db.Cats.Add(cat);
      await _db.SaveChangesAsync();

      return CreatedAtAction(nameof(GetCat), new { id = cat.CatId }, cat);
    }

    // GET: api/animalshelter/cats/1
    [HttpGet("{id}")]
    public async Task<ActionResult<Cat>> GetCat(int id)
    {
      var cat = await _db.Cats.FindAsync(id);

      if (cat == null)
      {
        return NotFound();
      }

      return Ok(new Response<Cat>(cat));
    }

    // PUT: api/animalshelter/cats/1
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Cat cat)
    {
      if (id != cat.CatId)
      {
        return BadRequest();
      }

      _db.Entry(cat).State = EntityState.Modified;
      
      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!CatExists(id))
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
    public async Task<IActionResult> DeleteCat(int id)
    {
      var cat = await _db.Cats.FindAsync(id);
      if (cat == null)
      {
        return NotFound();
      }

      _db.Cats.Remove(cat);
      await _db.SaveChangesAsync();

      return NoContent();
    }
    private bool CatExists(int id)
    {
      return _db.Cats.Any(e => e.CatId == id);
    }
  }
}