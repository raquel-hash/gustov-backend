using backend.Interfaces;
using backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _menuService;

        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<Dish>>> GetAllDishes()
        {
            var dishes = await _menuService.GetAllDishes();
            return Ok(dishes);
        }

        [HttpGet("visible")]
        [Authorize(Roles = "Admin,User")]
        public async Task<ActionResult<IEnumerable<Dish>>> GetVisibleDishes()
        {
            var dishes = await _menuService.GetVisibleDishes();
            return Ok(dishes);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> AddDish([FromBody] Dish dish)
        {
            var existingDish = await _menuService.GetDishByName(dish.Name);
            if (existingDish != null)
            {
                return Conflict(new { message = "El nombre del plato ya existe" });
            }
            await _menuService.AddDish(dish);
            return Ok();
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> UpdateDish(int id, [FromBody] Dish dish)
        {
            if (id != dish.Id)
            {
                return BadRequest("Dish ID mismatch");
            }

            var existingDish = await _menuService.GetDishById(id);
            if (existingDish == null)
            {
                return NotFound("Dish not found");
            }
            var dishWithSameName = await _menuService.GetDishByName(dish.Name);
            if (dishWithSameName != null && dishWithSameName.Id != id)
            {
                return Conflict(new { message = "El nombre del plato ya existe" });
            }

            await _menuService.UpdateDish(dish);
            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteDish(int id)
        {
            var existingDish = await _menuService.GetDishById(id);
            if (existingDish == null)
            {
                return NotFound("Dish not found");
            }

            await _menuService.DeleteDish(id);
            return Ok();
        }
    }
}