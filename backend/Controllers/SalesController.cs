using backend.Data;
using backend.Interfaces;
using backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class SalesController : ControllerBase
    {
        private readonly ISalesService _salesService;

        public SalesController(ISalesService salesService)
        {
            _salesService = salesService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Sale>> GetSales()
        {
            var sales = _salesService.GetSalesByDate(DateTime.UtcNow.Date);
            return Ok(sales);
        }

        [HttpPost("sale")]
        [Authorize(Roles = "Admin,User")]
        public ActionResult<Sale> PostSale([FromBody] Sale sale)
        {
            if (sale == null)
            {
                return BadRequest("Invalid data.");
            }

            TimeZoneInfo boliviaTimeZone = TimeZoneInfo.FindSystemTimeZoneById("SA Western Standard Time");
            DateTime boliviaTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, boliviaTimeZone);

            sale.Date = boliviaTime;
            _salesService.AddSale(sale);

            return CreatedAtAction(nameof(GetSales), new { id = sale.Id }, sale);
        }

        [HttpPost("saleitem")]
        [Authorize(Roles = "Admin,User")]
        public ActionResult<SaleItem> PostSaleItem([FromBody] SaleItem saleItem)
        {
            if (saleItem == null)
            {
                return BadRequest("Invalid data.");
            }

            if (!_salesService.DishExists(saleItem.DishId))
            {
                return BadRequest($"Plato con {saleItem.DishId} no existe.");
            }

            _salesService.AddSaleItem(saleItem);

            return CreatedAtAction(nameof(GetSales), new { id = saleItem.Id }, saleItem);
        }

        [HttpGet("daily-sales-report")]
        [Authorize(Roles = "Admin,User")]
        public ActionResult<IEnumerable<Sale>> GetDailySalesReport([FromQuery] DateTime date)
        {
            var sales = _salesService.GetSalesByDate(date);
            return Ok(sales);
        }
    }
}