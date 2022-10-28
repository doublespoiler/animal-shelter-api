using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AnimalShelterApi.Models;

namespace AnimalShelterApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnimalsController : ControllerBase
    {
      private readonly AnimalShelterContext _db;

      public AnimalsController(AnimalShelterContext db)
      {
        _db = db;
      }

      //GET api/animals
      [HttpGet]
      public async Task<ActionResult<IEnumerable<Animal>>> Get(int? id, string? sex, int? age, string? species, string? breed, string? color, bool? isFixed, string? name, int? olderThan, int? youngerThan)
      {
        IQueryable<Animal> query = _db.Animals.AsQueryable();

        if(id != null)
        {
          query = query.Where(a => a.Id == id);
        }
        if(sex != null)
        {
          query = query.Where(a => a.Sex == sex);
        }
        if(age != null)
        {
          query = query.Where(a => a.Age == age);
        }
        if(species == null)
        {
          query = query.Where(a => a.Species == species);
        }
        if(breed != null)
        {
          query = query.Where(a => a.Breed == breed);
        }
        if(color != null)
        {
          query = query.Where(a => a.Color == color);
        }
        if(isFixed != null)
        {
          query = query.Where(a => a.IsFixed == isFixed);
        }
        if(name != null)
        {
          query = query.Where(a => a.Name.Contains(name));
        }
        if(olderThan != null)
        {
          query = query.Where(a => a.Age >= olderThan);
        }
        if(youngerThan != null)
        {
          query = query.Where(a => a.Age <= youngerThan);
        }

        return await _db.Animals.ToListAsync();
      }

      // GET: api/Animals/5
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
      [HttpPost]
      public async Task<ActionResult<Animal>> Post(Animal animal)
      {
        _db.Animals.Add(animal);
        await _db.SaveChangesAsync();
        return CreatedAtAction("Post", new { id = animal.Id }, animal);
      }

    // PUT: api/Animals/5
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
      return _db.Animals.Any(a => a.Id == id);
    }
  }
}