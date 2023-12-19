using Golf_Capper.Data.Interface;
using Golf_Capper.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace Golf_Capper.Controllers
{
    [Route("api/GamePlayed")]
    [Controller]
    public class GamePlayedController : ControllerBase
    {
        private readonly Irepository _repository;
        public GamePlayedController(Irepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<GamePlayed>>> GetAllGamesPLayedAsync()

        {
            try
            {
                List<GamePlayed> gamePlayeds =  await _repository.GetAllGamesPLayedAsync();
                return Ok(gamePlayeds);
            }
            catch (Exception)
            {
                return StatusCode(500);

            }

            


        }



        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<GamePlayed>> GetGamePlayedById(int id)
        {
            try
            {
                GamePlayed? gamePlayed = await _repository.GetGamePlayedById(id);
                if(gamePlayed == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(gamePlayed);
                }
                
            }
            catch (Exception)
            {
                return StatusCode(500);

            }

            



        }
        [HttpPost]
        [ActionName("CreateGamePlayed")]
        public async Task<IActionResult> CreateGamePlayed([FromBody] GamePlayed gamePlayed)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _repository.CreateGamePlayed(gamePlayed);
                    return CreatedAtAction(nameof(GetGamePlayedById), new { id = gamePlayed.GamePlayedId }, gamePlayed);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception)
            {
                return StatusCode(500);

            }
            
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<GamePlayed>> DeleteGamePlayedAsync(int id)
        {
            try
            {
                bool deleteSuccesfull = await _repository.DeleteGamePlayedAsync(id);
                if (!deleteSuccesfull)
                {
                    return NotFound();
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception)
            {
                return StatusCode(500);

            }
            

        }


    }
}
