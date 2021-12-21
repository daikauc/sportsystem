using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportSystemAPI.Data.Workout;
using SportSystemAPI.Model;

namespace SportSystemAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkoutController : ControllerBase
    {
        public WorkoutController(IWorkoutRepo repository)
        {
            _repository = repository;
        }

        public readonly IWorkoutRepo _repository;

        // GET api/workout
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkoutModel>>> GetWorkoutListAsync()
        {
            var workoutList = await _repository.GetWorkoutListAsync();
            if (workoutList is null)
            {
                return NotFound();
            }
            return Ok(workoutList);
        }


        // GET api/workout/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<WorkoutModel>> GetWorkoutByIdAsync([FromRoute] int id)
        {
            var workoutFromRepo = await _repository.GetWorkoutByIdAsync(id);
            if (workoutFromRepo is null)
            {
                return NotFound();
            }
            return Ok(workoutFromRepo);
        }

        // POST api/workout
        [HttpPost]
        public async Task<ActionResult> CreateWorkoutAsync([FromBody] WorkoutModel workoutModel)
        {
            await _repository.CreateWorkoutAsync(workoutModel);
            await _repository.SaveChangesAsync();
            return NoContent();
        }

        // PUT api/workout
        [HttpPut]
        public async Task<ActionResult> UpdateWorkoutAsync([FromBody] WorkoutModel workoutModel)
        {
            await _repository.UpdateWorkoutAsync(workoutModel);

            await _repository.SaveChangesAsync();

            return NoContent();
        }

        // Delete api/workout/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteWorkoutByIdAsync([FromRoute] int id)
        {

            await _repository.DeleteWorkoutAsync(id);

            await _repository.SaveChangesAsync();
            return NoContent();
        }
    }
}