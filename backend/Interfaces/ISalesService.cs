
using backend.Models;

namespace backend.Interfaces
{
    public interface ISalesService
    {
        void AddSale(Sale sale);
        IEnumerable<Sale> GetSalesByDate(DateTime date);
        bool DishExists(int dishId);
        void AddSaleItem(SaleItem saleItem);
    }
}
