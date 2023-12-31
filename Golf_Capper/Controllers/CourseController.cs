﻿using Golf_Capper.Data.Interface;
using Golf_Capper.Models;
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
        public async Task<ActionResult<List<Course>>> GetAllCoursesAsync()
        {
            try
            {
                List<Course> courses = await _repository.GetAllCoursesAsync();

                return Ok(courses);
            }
            catch (Exception ex)
            {
                return StatusCode(500);

            }

        }


        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Course>> GetCourseById(int id)
        {
            try
            {
                Course? c = await _repository.GetCourseById(id);
                if (c == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(c);
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500);

            }


        }



        [HttpPost]
        [ActionName("CreateCourse")]
        public async Task<IActionResult> CreateCourse([FromBody] Course course)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _repository.CreateCourse(course);

                    return CreatedAtAction(nameof(GetCourseById), new { id = course.CourseId }, course);

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
        public async Task<IActionResult> UpdateCourse(int id, [FromBody] Course course)
        {
            try
            {
                Course UpdatedCourse = await _repository.UpdateCourseAsync(id, course);
                if (UpdatedCourse == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(UpdateCourse);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<Course>> DeleteCourseAsync(int id)
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
            catch (Exception ex)
            {
                return StatusCode(500);

            }
        }
    }
}

