using Golf_Capper.Data.Interface;
using Golf_Capper.Models;
//using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace Golf_Capper.Controllers
{
    [Route("api/course")]
    [Controller]
    public class CourseController : ControllerBase
    {
        private readonly Irepository _repository;
        public CourseController(Irepository repository)
        {
            _repository = repository;
        }


        [HttpGet]
        public async Task<ActionResult <List<Course>>> GetAllCoursesAsync()
        {
            try
            {
                List<Course> courses =  await _repository.GetAllCoursesAsync();

                return Ok(courses);
            }
            catch (Exception)
            {
                return StatusCode(500);

            }
            
        }


       [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Course>> GetCourseByIdAsync(int id)
        {
            try
            {
                Course? c = await _repository.GetCourseByIdAsync(id);
                if(c == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(c);
                }
                
            }
            catch (Exception)
            {
                return StatusCode(500);

            }

            
        }



        [HttpPost]
        public async Task<IActionResult> CreateCourse([FromBody] Course course)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _repository.CreateCourseAsync(course);

                    return CreatedAtAction(nameof(GetCourseByIdAsync), new { id = course.CourseId }, course);

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
            
        }//asdf



        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateCourse(int id, [FromBody] Course course)
        {
            try
            {
                Course upDateCourse = await _repository.UpdateCourseAsync(id, course);
                if (upDateCourse == null)
                {
                    return NotFound();
                }
                else
                {
                    return CreatedAtAction(nameof(UpdateCourse), new { id = course.CourseId }, course);
                }
            }
            catch (Exception)
            {
                return StatusCode(500);

            }
            
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<Course>> DeleteCourse(int id)
        {
            try
            {
                bool deleteSuccesfull = await _repository.DeleteCourseAsync(id);
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

