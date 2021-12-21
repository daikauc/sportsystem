using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportSystemAPI.Data.Subscription;
using SportSystemAPI.Model;

namespace SportSystemAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubController : ControllerBase
    {
        public SubController(ISubRepo repository)
        {
            _repository = repository;
        }

        public readonly ISubRepo _repository;

        // GET api/sub
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubModel>>> GetSubListAsync()
        {
            var subList = await _repository.GetSubListAsync();
            if (subList is null)
            {
                return NotFound();
            }
            return Ok(subList);
        }


        // GET api/sub/id/{id}
        [HttpGet("id/{id}")]
        public async Task<ActionResult<SubModel>> GetSubByIdAsync([FromRoute] int id)
        {
            var subFromRepo = await _repository.GetSubByIdAsync(id);
            if (subFromRepo is null)
            {
                return NotFound();
            }
            return Ok(subFromRepo);
        }

        // GET api/sub/{userId}
        [HttpGet("{userId}")]
        public async Task<ActionResult<SubModel>> GetSubByUserIdAsync([FromRoute] int userId)
        {
            var subFromRepo = await _repository.GetSubByUserIdAsync(userId);
            if (subFromRepo is null)
            {
                return NotFound();
            }
            return Ok(subFromRepo);
        }

        // POST api/sub
        [HttpPost]
        public async Task<ActionResult> CreateSubAsync([FromBody] SubModel subModel)
        {
            await _repository.CreateSubAsync(subModel);

            await _repository.SaveChangesAsync();

            return NoContent();
        }

        // PUT api/sub
        [HttpPut]
        public async Task<ActionResult> UpdateSubAsync([FromBody] SubModel subModel)
        {
            var model = await _repository.GetSubByUserIdAsync(subModel.UserId);

            model.UserId = subModel.UserId;
            model.Price = subModel.Price;
            model.Type = subModel.Type;
            model.Start = subModel.Start;
            model.End = subModel.End;
            model.Stopped = subModel.Stopped;
            model.Discount = subModel.Discount;

            await _repository.UpdateSubAsync(model);

            await _repository.SaveChangesAsync();

            return NoContent();
        }


        // Delete api/sub/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSubByIdAsync([FromRoute] int id)
        {
            await _repository.DeleteSubAsync(id);

            await _repository.SaveChangesAsync();
            return NoContent();
        }

    }
}