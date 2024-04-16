using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Cake_palace.models;
using Cake_palace.Services;



namespace Cake_palace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly ICartService _service;
        public CartsController(ICartService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetCarts()
        {
            return Ok(await _service.GetCarts());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCart(int id)
        {
            try
            {
                return Ok(await _service.GetCart(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddCart([FromBody] Cart cart)
        {
            try
            {
                await _service.AddCart(cart);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditCart(int id, [FromBody] Cart cart)
        {
            try
            {
                await _service.EditCart(id, cart);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCart(int id)
        {
            try
            {
                return Ok(await _service.DeleteCart(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
