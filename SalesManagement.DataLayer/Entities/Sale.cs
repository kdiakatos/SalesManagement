using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SalesManagement.DataLayer.Entities
{
    public class Sale
    {
        public Guid SaleId { get; set; }
        public Seller Seller { get; set; }
        public Guid SellerId { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal TransactionAmount { get; set; }
        public DateTime DateOfSale { get; set; }
    }
}
