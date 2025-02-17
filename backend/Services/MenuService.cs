using backend.Interfaces;
using backend.Models;
using backend.Repositories;

namespace backend.Services
{
    public class MenuService : IMenuService
    {
        private readonly MenuRepository _menuRepository;

        public MenuService(MenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public async Task<IEnumerable<Dish>> GetAllDishes()
        {
            return await _menuRepository.GetAllDishes();
        }

        public async Task<Dish> GetDishById(int id)
        {
            return await _menuRepository.GetDishById(id);
        }

        public async Task AddDish(Dish dish)
        {
            await _menuRepository.AddDish(dish);
        }

        public async Task UpdateDish(Dish dish)
        {
            await _menuRepository.UpdateDish(dish);
        }

        public async Task DeleteDish(int id)
        {
            await _menuRepository.DeleteDish(id);
        }

        public async Task<IEnumerable<Dish>> GetVisibleDishes()
        {
            return await _menuRepository.GetVisibleDishes();
        }

        public async Task<Dish> GetDishByName(string name)
        {
            return await _menuRepository.GetDishByName(name);
        }
    }
}