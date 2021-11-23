using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportSystemAPI.Data.Item;
using SportSystemAPI.Model;

namespace SportSystemAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
        public ItemController(IItemRepo repository)
        {
            _repository = repository;
        }

        public readonly IItemRepo _repository;

        // GET api/item
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemModel>>> GetItemListAsync()
        {
            var itemList = await _repository.GetItemListAsync();
            if (itemList is null)
            {
                return NotFound();
            }
            return Ok(itemList);
        }


        // GET api/item/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemModel>> GetItemByIdAsync([FromRoute] int id)
        {
            var itemFromRepo = await _repository.GetItemByIdAsync(id);
            if (itemFromRepo is null)
            {
                return NotFound();
            }
            return Ok(itemFromRepo);
        }

        // POST api/item
        [HttpPost]
        public async Task<ActionResult> CreateItemAsync([FromBody] ItemModel itemModel)
        {
            await _repository.CreateItemAsync(itemModel);

            _repository.SaveChanges();

            return NoContent();
        }
    }
}