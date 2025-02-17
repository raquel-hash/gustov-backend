using backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend.Interfaces
{
    public interface IMenuService
    {
        Task<IEnumerable<Dish>> GetAllDishes();
        Task<Dish> GetDishById(int id);
        Task AddDish(Dish dish);
        Task UpdateDish(Dish dish);
        Task DeleteDish(int id);
        Task<IEnumerable<Dish>> GetVisibleDishes();
        Task<Dish> GetDishByName(string name);
    }
}