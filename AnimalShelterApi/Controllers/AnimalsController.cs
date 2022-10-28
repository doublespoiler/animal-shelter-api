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
      public async Task<ActionResult<IEnumerable<Animal>>> Get()
      {
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
    }
}