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
    public class VideoGamesController(DataBaseWrapperContext dataBaseWrapperContext) : ControllerBase
    {
        private readonly DataBaseWrapperContext _dataBaseWrapperContext = dataBaseWrapperContext;
        // GET: api/GameConsole
        [HttpGet("get")]
        
        public async Task<IEnumerable<VideoGames>> GetCities()
        {


            return await _dataBaseWrapperContext.videoGamesDBSet.ToListAsync();


        }

        [HttpPost]
        public async Task<ActionResult<VideoGames>> PostVideoGame(VideoGames videoGame)
        {
            
            _dataBaseWrapperContext.videoGamesDBSet.Add(videoGame);
            try
            {
                
                await _dataBaseWrapperContext.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                
                if (VideoGamesExists(videoGame.Id))
                {
                    return Conflict(); 
                }
                else
                {
                    throw; 
                }
            }

            return CreatedAtAction("GetVideoGame", new { id = videoGame.Id }, videoGame);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<VideoGames>> GetVideogame(int id)
        {
            VideoGames? videoGame = await _dataBaseWrapperContext.videoGamesDBSet.FindAsync(id);

            if (videoGame == null)
            {
                return NotFound();
            }

            return videoGame;
        }

        // /api/any
        [HttpGet("any/{id}")]
        public async Task<ActionResult<VideoGames>> GetVideoGames(int id)
        {
            VideoGames? videoGames = await _dataBaseWrapperContext.videoGamesDBSet.FindAsync(id);

            if (videoGames == null)
            {
                return NotFound();
            }

            return videoGames;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutVideoGames(int id, VideoGames videoGames)
        {
            if (id != videoGames.Id)
            {
                return BadRequest();
            }

            _dataBaseWrapperContext.Entry(videoGames).State = EntityState.Modified;

            try
            {
                await _dataBaseWrapperContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VideoGamesExists(id))
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
        public async Task<IActionResult> DeleteVideoGames(int id)
        {
            VideoGames? videoGames = await _dataBaseWrapperContext.videoGamesDBSet.FindAsync(id);
            if (videoGames == null)
            {
                return NotFound();
            }

            _dataBaseWrapperContext.videoGamesDBSet.Remove(videoGames);
            await _dataBaseWrapperContext.SaveChangesAsync();

            return NoContent();
        }

        private bool VideoGamesExists(int id)
        {
            return _dataBaseWrapperContext.videoGamesDBSet.Any(e => e.Id == id);
        }
    }
}