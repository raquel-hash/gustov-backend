using backend.Interfaces;
using backend.Models;
using backend.Repositories;

namespace backend.Services
{
    public class SalesService : ISalesService
    {
        private readonly SalesRepository _salesRepository;

        public SalesService(SalesRepository salesRepository)
        {
            _salesRepository = salesRepository;
        }

        public void AddSale(Sale sale)
        {
            _salesRepository.AddSale(sale);
        }

        public IEnumerable<Sale> GetSalesByDate(DateTime date)
        {
            return _salesRepository.GetSalesByDate(date);
        }

        public bool DishExists(int dishId)
        {
            return _salesRepository.DishExists(dishId);
        }

        public void AddSaleItem(SaleItem saleItem)
        {
            _salesRepository.AddSaleItem(saleItem);
        }
    }
}
