using System;
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
    // [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AnimalsController : ControllerBase
    {
      private readonly AnimalShelterContext _db;
      private readonly IJWTManagerRepository _jWTManager;
      

      public AnimalsController(IJWTManagerRepository jWTManager, AnimalShelterContext db)
      {
        this._jWTManager = jWTManager;
        _db = db;
      }

      // [AllowAnonymous]
      [HttpPost]
      [Route("authenticate")]
      public IActionResult Authenticate (User user)
      {
        var token = _jWTManager.Authenticate(user);
        if(token == null)
        {
          return Unauthorized();
        }
        return Ok(token);
      }

      //GET api/animals
      // [AllowAnonymous]
      [HttpGet]
      public async Task<ActionResult<IEnumerable<Animal>>> Get(string sex, int? age, string species, string breed, string color, bool? isFixed, string name, int? olderThan, int? youngerThan, int? branchId)
      {
        IQueryable<Animal> query = _db.Animals.AsQueryable();

        if(sex != null)
        {
          query = query.Where(a => a.Sex == sex);
        }
        if(age != null)
        {
          query = query.Where(a => a.Age == age);
        }
        if(species != null)
        {
          query = query.Where(a => a.Species == species);
        }
        if(breed != null)
        {
          query = query.Where(a => a.Breed == breed);
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
        if(branchId != null)
        {
          query = query.Where(a => a.BranchId == branchId);
        }

        return await query.ToListAsync();
      }

      // GET: api/Animals/5
      // [AllowAnonymous]
      [HttpGet("{id}")]
      public async Task<ActionResult<Animal>> GetAnimal(int id)
      {
        var animal = await _db.Animals.FindAsync(id);
        if (animal == null)
        {
          return NotFound();
        }
        return animal;
      }

      // POST api/animals
      [Authorize]
      [HttpPost]
      public async Task<ActionResult<Animal>> Post(Animal animal)
      {
        _db.Animals.Add(animal);
        await _db.SaveChangesAsync();
        return CreatedAtAction("Post", new { id = animal.Id }, animal);
      }

    // PUT: api/Animals/5
    [Authorize]
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Animal animal)
    {
      if (id != animal.Id)
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

    // DELETE: api/Animals/5
    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAnimal(int id)
    {
      var animal = await _db.Animals.FindAsync(id);
      if (animal == null)
      {
        return NotFound();
      }
      var branch = await _db.Branches.FindAsync(animal.BranchId);
      branch.Animals.Remove(animal);
      _db.Animals.Remove(animal);
      await _db.SaveChangesAsync();
      return NoContent();
    }

    private bool AnimalExists(int id)
    {
      return _db.Animals.Any(a => a.Id == id);
    }
  }
}