using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Cake_palace.Data;
using Cake_palace.models;
using Cake_palace.Repository;
using Cake_palace.Services;


namespace Cake_palace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _service;
        public CategoriesController(ICategoryService service)
        {
            _service = service;
        }


        [HttpGet("{id}")]
        //[Authorize]
        public async Task<IActionResult> GetCategory(int id)
        {
            try
            {
                return Ok(await _service.GetCategory(id));

            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }


        }

        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> GetCategories()
        {
            return Ok(await _service.GetCategories());
        }


        [HttpPost("addCategory")]
        //[Authorize]
        public async Task<IActionResult> AddCategory([FromBody] Category category)
        {
            await _service.AddCategory(category);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{id}")]
        //[Authorize]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] Category category)
        {
            try
            {
                await _service.UpdateCategory(id, category);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }

        [HttpDelete("{id}")]
        //[Authorize]
        public async Task<IActionResult> DeleteCategory(int id)
        {

            try
            {
                await _service.DeleteCategory(id);
                return Ok("Category deleted successfully");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }

    }
}
