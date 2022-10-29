using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AnimalShelterApi.Models;
using Microsoft.AspNetCore.Authorization;
using AnimalShelterApi.Repository;

namespace AnimalShelterApi.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class BranchesController : ControllerBase
  {
      private readonly AnimalShelterContext _db;
      private readonly IJWTManagerRepository _jWTManager;

    public BranchesController(IJWTManagerRepository jWTManager, AnimalShelterContext db)
    {
      this._jWTManager = jWTManager;
      _db = db;
    }

    [HttpPost]
    [Route("authenticate")]
    public IActionResult Authenticate (User userdata)
    {
      var token = _jWTManager.Authenticate(userdata);
      if(token == null)
      {
        return Unauthorized();
      }
      return Ok(token);
    }

    //GET api/branches
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Branch>>> Get(string name, string address)
    {
      IQueryable<Branch> query = _db.Branches.AsQueryable();

      if(name != null)
      {
        query = query.Where(b => b.Name.ToLower().Contains(name.ToLower()));
      }
      if(address != null)
      {
        query = query.Where(b => b.Address.ToLower().Contains(address.ToLower()));
      }
      return await query.ToListAsync();
    }

    //GET: api/branches/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Branch>> GetBranch(int id)
    {
      var branch = await _db.Branches.FindAsync(id);
      if (branch == null)
      {
        return NotFound();
      }
      return branch;
    }

    //GET api/branches/5/animals
    [HttpGet("{id}/animals")]
    public async Task<ActionResult<IEnumerable<Animal>>> GetBranchAnimals(int id, string sex, string species, string breed, string color, bool? isFixed, string name, int? olderThan, int? youngerThan)
    {
      var branch = await _db.Branches.FindAsync(id);
      if (branch == null)
      {
        return NotFound();
      }
      IQueryable<Animal> query = _db.Animals.AsQueryable();
      query = query.Where(a => a.BranchId == id);
      if(sex != null)
      {
        query = query.Where(a => a.Sex.ToLower().Contains(sex.ToLower()));
      }
      if(species != null)
      {
        query = query.Where(a => a.Species.ToLower().Contains(species.ToLower()));
      }
      if(breed != null)
      {
        query = query.Where(a => a.Breed.ToLower().Contains(breed.ToLower()));
      }
      if(color != null)
      {
        query = query.Where(a => a.Color.ToLower().Contains(color.ToLower()));
      }
      if(isFixed != null)
      {
        query = query.Where(a => a.IsFixed == isFixed);
      }
      if(name != null)
      {
        query = query.Where(a => a.Name.ToLower().Contains(name.ToLower()));
      }
      if(olderThan != null)
      {
        query = query.Where(a => a.Age >= olderThan);
      }
      if(youngerThan != null)
      {
        query = query.Where(a => a.Age <= youngerThan);
      }
      return await query.ToListAsync();
    }

    //POST api/branches
    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Branch>> Post(Branch branch)
    {
      _db.Branches.Add(branch);
      await _db.SaveChangesAsync();
      return CreatedAtAction("Post", new { id = branch.Id }, branch);
    }
    [HttpPost("{id}/animals")]
    public async Task<ActionResult<Animal>> PostAnimal(int id, Animal animal)
      {
        animal.BranchId = id;
        _db.Animals.Add(animal);
        await _db.SaveChangesAsync();
        return CreatedAtAction("PostAnimal", new { id = animal.Id}, animal);
      }

    //PUT: api/branches/5
    [Authorize]
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Branch branch)
    {
      if (id != branch.Id)
      {
        return BadRequest();
      }

      _db.Entry(branch).State = EntityState.Modified;

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!BranchExists(id))
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

    //DELETE: api/branches/5
    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBranch(int id)
    {
      var branch = await _db.Branches.FindAsync(id);
      if (branch == null)
      {
        return NotFound();
      }
      _db.Branches.Remove(branch);
      await _db.SaveChangesAsync();
      return NoContent();
    }

    private bool BranchExists(int id)
    {
      return _db.Branches.Any(b => b.Id == id);
    }
  }
}