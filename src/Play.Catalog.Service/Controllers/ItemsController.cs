using Microsoft.AspNetCore.Mvc;
using Play.Catalog.Service.Entities;
namespace Play.Catalog.Service.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemsController : ControllerBase
    {

        public ItemsController()
        {

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> GetAsync()
        {
            var item = new Item
            {
                Name = "My Name",
                Description = "Desc",
                Price = 5,
                CreatedDate = DateTimeOffset.UtcNow
            };
            IEnumerable<Item> items = new List<Item>() { item };
            var task = await Task.FromResult(items);

            return Ok(task);
        }


    }
}