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
        public ActionResult<List<Golfer>> GetAllGolfersAsync()
        {
            try
            {
                List<Golfer> golfers =_repository.GetAllGolfersAsync();
                return Ok(golfers);
            }
            catch (Exception)
            {
                return StatusCode(500);

            }
            
        }
        

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Golfer> GetGolferById(int id)
        {
            try
            {
                Golfer golfer = _repository.GetGolferById(id);
                return Ok(golfer);
            }
            catch (Exception)
            {
                return StatusCode(500);

            }
            
        }


        [HttpPost]
        public IActionResult CreateGolfer([FromBody] Golfer golfer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repository.CreateGolfer(golfer);
                    return CreatedAtAction(nameof(GetGolferById), new { id = golfer.GolferId }, golfer);
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
        public IActionResult UpdateGolfer(int id, [FromBody] Golfer golfer)
        {
            try
            {
                Golfer GolferToUpdate = _repository.UpdateGolfer(id, golfer);
                if (GolferToUpdate == null)
                {
                    return NotFound();
                }
                else
                {
                    return CreatedAtAction(nameof(UpdateGolfer), new { id = golfer.GolferId }, golfer);
                }
            }
            catch (Exception)
            {
                return StatusCode(500);

            }
            
        }


        [HttpDelete]
        [Route("{id}")]
        public ActionResult<Golfer> DeleteGolfer(int id)
        {
            try
            {
                bool deleteSuccesfull = _repository.DeleteGolfer(id);
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
