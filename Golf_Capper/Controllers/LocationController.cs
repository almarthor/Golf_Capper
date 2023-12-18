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
        public async Task<ActionResult<List<Location>>> GetAllLocationsAsync()

        {
            try
            {
                List<Location> locations = await _repository.GetAllLocationsAsync();
                return Ok(locations);
            }
            catch (Exception)
            {
                return StatusCode(500);

            }

        }


        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Location>> GetLocationByIdAsync(int id)
        {
            try
            {
                Location? location = await _repository.GetLocationByIdAsync(id);
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
        public async Task<IActionResult> CreateLocation([FromBody] Location location)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _repository.CreateLocationAsync(location);
                    return CreatedAtAction(nameof(GetLocationByIdAsync), new { id = location.LocationId }, location);
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
        public async Task<IActionResult> UpdateLocationAsync(int id, [FromBody] Location location)
        {
            try
            {
                Location LocationToUpdate = await _repository.UpdateLocationAsync(id, location);
                if (LocationToUpdate == null)
                {
                    return NotFound();
                }
                else
                {
                    return CreatedAtAction(nameof(UpdateLocationAsync), new { id = location.LocationId }, location);
                }
            }
            catch (Exception)
            {
                return StatusCode(500);

            }

        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<Location>> DeleteLocationAsync(int id)
        {
            try
            {
                bool deleteSuccesfull = await _repository.DeleteLocationAsync(id);
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
