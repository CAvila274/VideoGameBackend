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
    public class GameConsoleController(DataBaseWrapperContext dataBaseWrapperContext) : ControllerBase
    {
        //private readonly MycitiesContext _context = context;
        private readonly DataBaseWrapperContext _dataBaseWrapperContext = dataBaseWrapperContext;
        // GET: api/Cities
        [HttpGet("get")]
        //public async Task<GameConsole> GetCities()
         public async Task<IEnumerable<GameConsole>> GetCities()
        {
        //GameConsole ourTable = await _dataBaseWrapperContext.testMyDBContext();

         return await _dataBaseWrapperContext.gameConsoleDBSet.ToListAsync();

        //IQueryable<GameConsole> x = _context.Cities.Select(c => new GameConsole
        //{
        //    Id = c.Id,
        //    Name = c.Name,
        //    ReleaseDate=c.ReleaseDate

        //}).Take(100);



        // return ourTable;

         }

        // POST: /api/Cities
        [HttpPost]
        public async Task<ActionResult<GameConsole>> PostGameConsole(GameConsole gameConsole)
        {
            // Add the new game console to the DbSet
            _dataBaseWrapperContext.gameConsoleDBSet.Add(gameConsole);
            try
            {
                // Save changes to the database
                await _dataBaseWrapperContext.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                // Check if the game console already exists (if you have a unique constraint on Id)
                if (GameConsoleExists(gameConsole.Id))
                {
                    return Conflict(); // Return a conflict status if it does
                }
                else
                {
                    throw; // Rethrow the exception if it is not a conflict
                }
            }

            // Return the created game console with a 201 Created response
            return CreatedAtAction("GetGameConsole", new { id = gameConsole.Id }, gameConsole);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GameConsole>> GetGameConsole(int id)
        {
            GameConsole? gameConsole = await _dataBaseWrapperContext.gameConsoleDBSet.FindAsync(id);

            if (gameConsole == null)
            {
                return NotFound();
            }

            return gameConsole;
        }

        // /api/any
        [HttpGet("any/{id}")]
        public async Task<ActionResult<GameConsole>> GetGameConole(int id)
        {
            GameConsole? gameConsole = await _dataBaseWrapperContext.gameConsoleDBSet.FindAsync(id);

            if (gameConsole == null)
            {
                return NotFound();
            }

            return gameConsole;
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGameConsole(int id)
        {
            GameConsole? gameconsole = await _dataBaseWrapperContext.gameConsoleDBSet.FindAsync(id);
            if (gameconsole == null)
            {
                return NotFound();
            }

            _dataBaseWrapperContext.gameConsoleDBSet.Remove(gameconsole);
            await _dataBaseWrapperContext.SaveChangesAsync();

            return NoContent();
        }


        private bool GameConsoleExists(int id)
        {
            return _dataBaseWrapperContext.gameConsoleDBSet.Any(e => e.Id == id);
        }
    }
}
