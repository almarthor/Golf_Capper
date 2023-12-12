using Golf_Capper.Data.Interface;
using Golf_Capper.Models;
using Microsoft.AspNetCore.Mvc;

namespace Golf_Capper.Controllers
{
    [Route("api/location")]
    [Controller]
    public class LocationController : ControllerBase
    {
        private readonly Irepository _repository;
        public LocationController(Irepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<List<Location>> GetAllLocations()

        {
            try
            {
                List<Location> locations = _repository.GetAllLocationsAsync();
                return Ok(locations);
            }
            catch (Exception)
            {
                return StatusCode(500);

            }

        }


        [HttpGet]
        [Route("{id}")]
        public ActionResult<Location> GetLocationById(int id)
        {
            try
            {
                Location location = _repository.GetLocationById(id);
                if (location == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(location);
                }

            }
            catch (Exception)
            {
                return StatusCode(500);

            }

        }


        [HttpPost]
        public IActionResult CreateLocation([FromBody] Location location)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repository.CreateLocation(location);
                    return CreatedAtAction(nameof(GetLocationById), new { id = location.LocationId }, location);
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
        public IActionResult UpdateLocation(int id, [FromBody] Location location)
        {
            try
            {
                Location LocationToUpdate = _repository.UpdateLocation(id, location);
                if (LocationToUpdate == null)
                {
                    return NotFound();
                }
                else
                {
                    return CreatedAtAction(nameof(UpdateLocation), new { id = location.LocationId }, location);
                }
            }
            catch (Exception)
            {
                return StatusCode(500);

            }

        }


        [HttpDelete]
        [Route("{id}")]
        public ActionResult<Location> DeleteLocation(int id)
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
