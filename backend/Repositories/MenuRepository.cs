using backend.Data;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories
{
    public class MenuRepository
    {
        private readonly GustovDbContext _context;

        public MenuRepository(GustovDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Dish>> GetAllDishes()
        {
            return await _context.Dish.ToListAsync();
        }

        public async Task<Dish> GetDishById(int id)
        {
            return await _context.Dish.FindAsync(id);
        }

        public async Task AddDish(Dish dish)
        {
            await _context.Dish.AddAsync(dish);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateDish(Dish dish)
        {
            var existingDish = await _context.Dish.FindAsync(dish.Id);
            if (existingDish != null)
            {
                existingDish.Name = dish.Name;
                existingDish.Price = dish.Price;
                existingDish.ImageUrl = dish.ImageUrl;
                existingDish.ShowInMenu = dish.ShowInMenu;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteDish(int id)
        {
            var dish = await _context.Dish.FindAsync(id);
            if (dish != null)
            {
                _context.Dish.Remove(dish);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Dish>> GetVisibleDishes()
        {
            return await _context.Dish.Where(d => d.ShowInMenu).ToListAsync();
        }

        public async Task<Dish> GetDishByName(string name)
        {
            return await _context.Dish.FirstOrDefaultAsync(d => d.Name == name);
        }
    }
}
