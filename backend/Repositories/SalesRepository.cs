using backend.Data;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories
{
    public class SalesRepository
    {
        private readonly GustovDbContext _context;

        public SalesRepository(GustovDbContext context)
        {
            _context = context;
        }

        public void AddSale(Sale sale)
        {
            _context.Sale.Add(sale);
            _context.SaveChanges();
        }

        public IEnumerable<Sale> GetSalesByDate(DateTime date)
        {
            return _context.Sale
                .Include(s => s.SaleItems)
                .ThenInclude(si => si.Dish)
                .Where(s => s.Date.Date == date.Date)
                .ToList();
        }

        public bool DishExists(int dishId)
        {
            return _context.Dish.Any(d => d.Id == dishId);
        }

        public void AddSaleItem(SaleItem saleItem)
        {
            _context.SaleItem.Add(saleItem);
            _context.SaveChanges();
        }
    }
}
