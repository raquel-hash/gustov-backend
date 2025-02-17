using System;
using System.Collections.Generic;

namespace backend.Models
{
    public class Sale
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime Date { get; set; }
        public List<SaleItem>? SaleItems { get; set; }
    }
}