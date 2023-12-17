//using Microsoft.AspNetCore.Components;
using Golf_Capper.Data.Interface;
using Golf_Capper.Models;
using Microsoft.AspNetCore.Mvc;

namespace Golf_Capper.Controllers
{
    [Route("api/courseHolePar")]
    [Controller]
    public class CourseHoleParController : ControllerBase
    {
        private readonly Irepository _repository;
        public CourseHoleParController(Irepository repository)
        {
            _repository = repository;
        }



        [HttpGet]
        public async Task<ActionResult<List<CourseHolePar>>> GetAllCourseHoleParsAsync()
        {
            try
            {
                List<CourseHolePar> courses = await _repository.GetAllCourseHoleParsAsync();

                return Ok(courses);
            }
            catch (Exception)
            {
                return StatusCode(500);

            }

        }


        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<CourseHolePar>> GetCourseHoleParByIdAsync(int id)
        {
            try
            {
                CourseHolePar? courseHolePar = await _repository.GetCourseHoleParByIdAsync(id);
                if(courseHolePar == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(courseHolePar);
                }
                
            }
            catch (Exception)
            {
                return StatusCode(500);

            }

        }


        [HttpPost]
        public async Task<IActionResult> CreateCourseHoleParAsync([FromBody] CourseHolePar courseHolePar)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _repository.CreateCourseHoleParAsync(courseHolePar);
                    return CreatedAtAction(nameof(GetCourseHoleParByIdAsync), new { id = courseHolePar.CourseHoleParId }, courseHolePar);
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
        public async Task<IActionResult> UpdateCourseHoleParAsync(int id, [FromBody] CourseHolePar courseHolePar)
        {
            try
            {
                CourseHolePar upDateCourseHolePar = await _repository.UpdateCourseHoleParAsync(id, courseHolePar);
                if (upDateCourseHolePar == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(CreatedAtAction(nameof(upDateCourseHolePar), new { id = courseHolePar.CourseHoleParId }, courseHolePar));
                }
            }
            catch (Exception)
            {
                return StatusCode(500);

            }

        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<CourseHolePar>> DeleteCourseHoleParAsync(int id)
        {
            try
            {
                bool deleteSuccesfull = await _repository.DeleteCourseHoleParAsync(id);
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
