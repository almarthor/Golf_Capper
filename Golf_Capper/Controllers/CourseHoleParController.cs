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
        public ActionResult<List<CourseHolePar>> GetAllCourseHoleParsAsync()
        {
            try
            {
                List<CourseHolePar> courses = _repository.GetAllCourseHoleParsAsync();

                return Ok(courses);
            }
            catch (Exception)
            {
                return StatusCode(500);

            }

        }

        
                [HttpGet]
                [Route("{id}")]
                public ActionResult<CourseHolePar> GetCourseHoleParById(int id)
                {
                    try
                    {
                CourseHolePar courseHolePar = _repository.GetCourseHoleParById(id);
                        return Ok(courseHolePar);
                    }
                    catch (Exception)
                    {
                        return StatusCode(500);

                    }

                }


                [HttpPost]
                public IActionResult CreateCourseHolePar([FromBody] CourseHolePar courseHolePar)
                {
                    try
                    {
                        if (ModelState.IsValid)
                        {
                            _repository.CreateCourseHolePar(courseHolePar);
                            return CreatedAtAction(nameof(GetCourseHoleParById), new { id = courseHolePar.CourseHoleParId }, courseHolePar);
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
                public IActionResult UpdateCourseHolePar(int id, [FromBody] CourseHolePar courseHolePar)
                {
                    try
                    {
                        CourseHolePar upDateCourseHolePar = _repository.UpdateCourseHolePar(id, courseHolePar);
                        if (upDateCourseHolePar == null)
                        {
                            return NotFound();
                        }
                        else
                        {
                            return CreatedAtAction(nameof(upDateCourseHolePar), new { id = courseHolePar.CourseHoleParId }, courseHolePar);
                        }
                    }
                    catch (Exception)
                    {
                        return StatusCode(500);

                    }

                }


                [HttpDelete]
                [Route("{id}")]
                public ActionResult<CourseHolePar> DeleteCourseHolePar(int id)
                {
                    try
                    {
                        bool deleteSuccesfull = _repository.DeleteCourseHolePar(id);
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
