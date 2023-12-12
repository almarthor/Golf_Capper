//using Microsoft.AspNetCore.Components;
using Golf_Capper.Data.Interface;
using Golf_Capper.Models;
using Microsoft.AspNetCore.Mvc;

namespace Golf_Capper.Controllers
{
    [Route("api/score")]
    [Controller]
    public class ScoreController : ControllerBase
    {
        private readonly Irepository _repository;

        public ScoreController(Irepository repository)
        {

            _repository = repository;
        }

        [HttpGet]
        public  ActionResult<List<Score>> GetAllScoresAsync()

        {
            try
            {
                List<Score> scores = _repository.GetAllScoresAsync();
                return Ok(scores);
            }
            catch (Exception)
            {
                return StatusCode(500);

            }
            
        }
        

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Score> GetScoreById(int id)
        {

            try
            {

                Score score = _repository.GetScoreById(id);

                return Ok(score);
            }
            catch (Exception)
            {
                return StatusCode(500);

            }
            
        }

        [HttpPost]
        public IActionResult CreateScore([FromBody] Score score)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repository.CreateScore(score);

                    return CreatedAtAction(nameof(GetScoreById), new { id = score.ScoreId }, score);
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

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateScore(int id, [FromBody] Score score)
        {
            try
            {
                Score ScoreToUpdate = _repository.UpdateScore(id, score);
                if (ScoreToUpdate == null)
                {
                    return NotFound();
                }
                else
                {
                    return CreatedAtAction(nameof(UpdateScore), new { id = score.ScoreId }, score);
                }
            }
            catch (Exception)
            {
                return StatusCode(500);

            }
            
        }
        [HttpDelete]
        [Route("{id}")]
        public ActionResult<Score> DeleteScore(int id)
        {
            try
            {
                bool deleteSuccesfull = _repository.DeleteScore(id);
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
