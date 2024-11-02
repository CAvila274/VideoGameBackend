using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataModel;
using System.Runtime;
using AngularCOMP584.Server.DTO;
using AngularCOMP584.Server.Models2;

namespace AngularCOMP584.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController(MycitiesContext context) : ControllerBase
    {
        private readonly MycitiesContext _context = context;
        //private readonly DataBaseWrapperContext _dataBaseWrapperContext = dataBaseWrapperContext;
        // GET: api/Cities
       // [HttpGet("game")]
        //public async Task<GameConsole> GetCities()
       // public async Task<IEnumerable<GameConsole>> GetCities()
        
        //GameConsole ourTable = await _dataBaseWrapperContext.testMyDBContext();

       // return await _dataBaseWrapperContext.gameConsoleDBSet.ToListAsync();

        //IQueryable<GameConsole> x = _context.Cities.Select(c => new GameConsole
        //{
        //    Id = c.Id,
        //    Name = c.Name,
        //    ReleaseDate=c.ReleaseDate

        //}).Take(100);



       // return ourTable;

    

    


        // GET: api/Cities/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<City>> GetCity(int id)
        //{
        //    City? city = await _context.Cities.FindAsync(id);

        //    if (city == null)
        //    {
        //        return NotFound();
        //    }

        //    return city;
        //}

        //// PUT: api/Cities/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutCity(int id, City city)
        //{
        //    if (id != city.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(city).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CityExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Cities
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost("cities2")]
        //public async Task<ActionResult<City>> PostCity(City city)
        //{
        //    _context.Cities.Add(city);
        //    try
        //    {

        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (CityExists(city.Id))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtAction("GetCity", new { id = city.Id }, city);
        //}

        //// DELETE: api/Cities/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteCity(int id)
        //{
        //    City? city = await _context.Cities.FindAsync(id);
        //    if (city == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Cities.Remove(city);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool CityExists(int id)
        //{
        //    return _context.Cities.Any(e => e.Id == id);
        //}

      
    }
}
