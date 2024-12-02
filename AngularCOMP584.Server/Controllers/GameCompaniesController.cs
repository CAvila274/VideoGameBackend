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
using DataModel.Models2;


namespace AngularCOMP584.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameCompaniesController(DataBaseWrapperContext dataBaseWrapperContext) : ControllerBase
    {
        
        private readonly DataBaseWrapperContext _dataBaseWrapperContext = dataBaseWrapperContext;
        
        [HttpGet("get")]
        
        public async Task<IEnumerable<GameCompanies>> GetCities()
        {
           

            return await _dataBaseWrapperContext.gameCompaniesDBSet.ToListAsync();


        }

        [HttpPost("post")]
        public async Task<ActionResult<GameCompanies>> PostGameConsole(GameCompaniesDTO gameCompaniesDTO)
        {
            // Map DTO to entity
            var gameCompanies = new GameCompanies
            {
                
                Name = gameCompaniesDTO.Name,
                FoundedDate = gameCompaniesDTO.FoundedDate,
              

            };


            _dataBaseWrapperContext.gameCompaniesDBSet.Add(gameCompanies);

            try
            {

                await _dataBaseWrapperContext.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {

                if (GameCompaniesExists(gameCompanies.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }


            return CreatedAtAction(nameof(GetGameCompanies), new { id = gameCompanies.Id }, gameCompanies);
        }




        [HttpPost]
        public async Task<ActionResult<GameCompanies>> PostGameCompanies(GameCompanies gameCompanies)
        {
            
            _dataBaseWrapperContext.gameCompaniesDBSet.Add(gameCompanies);
            try
            {
                
                await _dataBaseWrapperContext.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                
                if (GameCompaniesExists(gameCompanies.Id))
                {
                    return Conflict(); 
                }
                else
                {
                    throw; 
                }
            }

            
            return CreatedAtAction("GetGameCompanies", new { id = gameCompanies.Id }, gameCompanies);
        }

        // /api/any
        [HttpGet("any/{id}")]
        public async Task<ActionResult<GameCompanies>> GetGameCompanies(int id)
        {
            GameCompanies? gameCompanies = await _dataBaseWrapperContext.gameCompaniesDBSet.FindAsync(id);

            if (gameCompanies == null)
            {
                return NotFound();
            }

            return gameCompanies;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameCompaniesDTO>>> GetGameCompanies()
        {
            return await _dataBaseWrapperContext.gameCompaniesDBSet
                .Select(company => new GameCompaniesDTO
                {
                    Id = company.Id, 
                    Name = company.Name,
                    FoundedDate = company.FoundedDate
                }).ToListAsync();
        }


       

        [HttpPut("{id}")]
        public async Task<IActionResult> PutGameCompanies(int id, GameCompanies gamecompanies)
        {
            if (id != gamecompanies.Id)
            {
                return BadRequest();
            }

            _dataBaseWrapperContext.Entry(gamecompanies).State = EntityState.Modified;

            try
            {
                await _dataBaseWrapperContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameCompaniesExists(id))
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
        public async Task<IActionResult> DeleteGameCompanies(int id)
        {
            GameCompanies? gamecompanies = await _dataBaseWrapperContext.gameCompaniesDBSet.FindAsync(id);
            if (gamecompanies == null)
            {
                return NotFound();
            }

            _dataBaseWrapperContext.gameCompaniesDBSet.Remove(gamecompanies);
            await _dataBaseWrapperContext.SaveChangesAsync();

            return NoContent();
        }

      

        private bool GameCompaniesExists(int id)
        {
            return _dataBaseWrapperContext.gameCompaniesDBSet.Any(e => e.Id == id);
        }

    }
}
