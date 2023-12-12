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
        public ActionResult<List<GamePlayed>> GetAllGamesPLayedAsync()

        {
            try
            {
                List<GamePlayed> gamePlayeds =  _repository.GetAllGamesPLayedAsync();
                return Ok(gamePlayeds);
            }
            catch (Exception)
            {
                return StatusCode(500);

            }

            


        }



        [HttpGet]
        [Route("{id}")]
        public ActionResult<GamePlayed> GetGamePlayedById(int id)
        {
            try
            {
                GamePlayed gamePlayed = _repository.GetGamePlayedById(id);
                return Ok(gamePlayed);
            }
            catch (Exception)
            {
                return StatusCode(500);

            }

            



        }
        [HttpPost]
        public IActionResult CreateGamePlayed([FromBody] GamePlayed gamePlayed)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repository.CreateGamePlayed(gamePlayed);
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
        public ActionResult<GamePlayed> DeleteGamePlayed(int id)
        {
            try
            {
                bool deleteSuccesfull = _repository.DeleteGamePlayed(id);
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
