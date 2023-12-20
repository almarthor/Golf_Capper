using Golf_Capper.Data.Interface;
using Golf_Capper.Models;
using Microsoft.AspNetCore.Mvc;

namespace Golf_Capper.Controllers
{
    [Route("api/golfer")]
    [Controller]
    public class GolferController : ControllerBase
    {
        private readonly Irepository _repository;
        public GolferController(Irepository repository)
        {
            _repository = repository;
        }


        [HttpGet]
        public async Task<ActionResult<List<Golfer>>> GetAllGolfersAsync()
        {
            try
            {
                List<Golfer> golfers = await _repository.GetAllGolfersAsync();
                return Ok(golfers);
            }
            catch (Exception ex)
            {
                return StatusCode(500);

            }
            
        }
        

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Golfer>> GetGolferById(int id)
        {
            try
            {
                Golfer? golfer = await _repository.GetGolferById(id);
                if(golfer == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(golfer);
                }
                
            }
            catch (Exception ex)
            {
                return StatusCode(500);

            }
            
        }


        [HttpPost]
        [ActionName("CreateGolfer")]
        public async Task<IActionResult> CreateGolfer([FromBody] Golfer golfer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _repository.CreateGolfer(golfer);
                    return CreatedAtAction(nameof(GetGolferById), new { id = golfer.GolferId }, golfer);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500);

            }
            
        }


        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateGolferAsync(int id, [FromBody] Golfer golfer)
        {
            try
            {
                Golfer GolferToUpdate = await _repository.UpdateGolferAsync(id, golfer);
                if (GolferToUpdate == null)
                {
                    return NotFound();
                }
                else
                {
                    return CreatedAtAction(nameof(UpdateGolferAsync), new { id = golfer.GolferId }, golfer);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500);

            }
            
        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<Golfer>> DeleteGolferAsync(int id)
        {
            try
            {
                bool deleteSuccesfull = await _repository.DeleteGolferAsync(id);
                if (!deleteSuccesfull)
                {
                    return NotFound();
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500);

            }

            

        }
        
    }
}
