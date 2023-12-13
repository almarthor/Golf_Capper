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
        public async Task<ActionResult<List<Score>>> GetAllScoresAsync()

        {
            try
            {
                List<Score> scores = await _repository.GetAllScoresAsync();
                return Ok(scores);
            }
            catch (Exception)
            {
                return StatusCode(500);

            }
            
        }
        

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Score>> GetScoreByIdAsync(int id)
        {

            try
            {
                
                Score score = await _repository.GetScoreByIdAsync(id);
                if (score == null)
                {
                    return NotFound();

                }
                else
                {
                return Ok(score);
                }


            }
            catch (Exception)
            {
                return StatusCode(500);

            }
            
        }

        [HttpPost]
        public async Task<IActionResult> CreateScoreAsync([FromBody] Score score)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _repository.CreateScoreAsync(score);

                    return CreatedAtAction(nameof(GetScoreByIdAsync), new { id = score.ScoreId }, score);
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
        public async Task<IActionResult> UpdateScore(int id, [FromBody] Score score)
        {
            try
            {
                Score ScoreToUpdate = await _repository.UpdateScoreAsync(id, score);
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
        public async Task<ActionResult<Score>> DeleteScoreAsync(int id)
        {
            try
            {
                bool deleteSuccesfull = await _repository.DeleteScoreAsync(id);
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
