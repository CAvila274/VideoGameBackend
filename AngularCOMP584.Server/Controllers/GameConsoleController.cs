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
using DataModel.NewFolder;

namespace AngularCOMP584.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameConsoleController(DataBaseWrapperContext dataBaseWrapperContext) : ControllerBase
    {
        
        private readonly DataBaseWrapperContext _dataBaseWrapperContext = dataBaseWrapperContext;
        // GET: api/GameConsole
        [HttpGet("get")]
        
         public async Task<IEnumerable<GameConsole>> GetCities()
        {
       

         return await _dataBaseWrapperContext.gameConsoleDBSet.ToListAsync();


         }

        // POST: /api/GameConsole
        [HttpPost]
        public async Task<ActionResult<GameConsole>> PostGameConsole(GameConsole gameConsole)
        {
            
            _dataBaseWrapperContext.gameConsoleDBSet.Add(gameConsole);
            try
            {
                
                await _dataBaseWrapperContext.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                
                if (GameConsoleExists(gameConsole.Id))
                {
                    return Conflict(); 
                }
                else
                {
                    throw; 
                }
            }

            
            return CreatedAtAction("GetGameConsole", new { id = gameConsole.Id }, gameConsole);
        }

        // /api/GameConsole/whatever

        [HttpGet("whatever")]
        public async Task<ActionResult<WhateverViewModel>> asdf()
        {
            WhateverViewModel w = new WhateverViewModel();
            w.id = 3;
            w.name = "jon";

            return w;
        }



        // /api/GameConsole/post
        [HttpPost("post")]
        public async Task<ActionResult<GameConsole>> PostGameConsole(GameConsoleDTO gameConsoleDTO)
        {
            // Map DTO to entity
            var gameConsole = new GameConsole
            {
                Id = gameConsoleDTO.Id, 
                Name = gameConsoleDTO.Name,
                ReleaseDate = gameConsoleDTO.ReleaseDate,
                CompanyId = gameConsoleDTO.CompanyId,
                IsCrossPlatform = gameConsoleDTO.IsCrossPlatform,
                ConsoleType = gameConsoleDTO.ConsoleType
                
            };

            
            _dataBaseWrapperContext.gameConsoleDBSet.Add(gameConsole);

            try
            {
               
                await _dataBaseWrapperContext.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                
                if (GameConsoleExists(gameConsole.Id))
                {
                    return Conflict(); 
                }
                else
                {
                    throw; 
                }
            }

            
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

        [HttpPut("{id}")]
        public async Task<IActionResult> PutGameConsole(int id, GameConsole gameconsole)
        {
            if (id != gameconsole.Id)
            {
                return BadRequest();
            }

            _dataBaseWrapperContext.Entry(gameconsole).State = EntityState.Modified;

            try
            {
                await _dataBaseWrapperContext.SaveChangesAsync();
           }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameConsoleExists(id))
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
