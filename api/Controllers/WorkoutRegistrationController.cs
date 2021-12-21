using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportSystemAPI.Data.WorkoutRegistration;
using SportSystemAPI.Model;

namespace SportSystemAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkoutRegistrationController : ControllerBase
    {
        public WorkoutRegistrationController(IWorkoutRegistrationRepo repository)
        {
            _repository = repository;
        }

        public readonly IWorkoutRegistrationRepo _repository;

        // GET api/workoutRegistration
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkoutRegistrationModel>>> GetWorkoutRegistrationListAsync()
        {
            var workoutRegistrationList = await _repository.GetWorkoutRegistrationListAsync();
            if (workoutRegistrationList is null)
            {
                return NotFound();
            }
            return Ok(workoutRegistrationList);
        }


        // GET api/workout_reg/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<WorkoutRegistrationModel>> GetWorkoutRegistrationByIdAsync([FromRoute] int id)
        {
            var workoutRegistrationFromRepo = await _repository.GetWorkoutRegistrationByIdAsync(id);
            if (workoutRegistrationFromRepo is null)
            {
                return NotFound();
            }
            return Ok(workoutRegistrationFromRepo);
        }

        // GET api/workout_reg/{id}
        [HttpGet("{userid}/{byuser}")]
        public async Task<ActionResult<WorkoutRegistrationModel>> GetWorkoutRegistrationByUserIdAsync([FromRoute] int userid)
        {
            var workoutRegistrationFromRepo = await _repository.GetWorkoutRegistrationByUserIdAsync(userid);
            if (workoutRegistrationFromRepo is null)
            {
                return NotFound();
            }
            return Ok(workoutRegistrationFromRepo);
        }

        // POST api/workout
        [HttpPost]
        public async Task<ActionResult> CreateWorkoutRegistrationAsync([FromBody] WorkoutRegistrationModel workoutRegistration)
        {
            await _repository.CreateWorkoutRegistrationAsync(workoutRegistration.UserId, workoutRegistration.WorkoutId);
            await _repository.SaveChangesAsync();
            return NoContent();
        }

        // Delete api/workout/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteWorkoutRegistrationByIdAsync([FromRoute] int id)
        {
            await _repository.DeleteWorkoutRegistrationAsync(id);
            await _repository.SaveChangesAsync();
            return NoContent();
        }
    }
}