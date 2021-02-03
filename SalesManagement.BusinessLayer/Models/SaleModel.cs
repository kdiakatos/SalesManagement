using System;

namespace SalesManagement.BusinessLayer.Models
{
    public class SaleModel
    {
        public Guid SaleId { get; set; }
        public SellerModel Seller { get; set; }
        public Guid SellerId { get; set; }
        public decimal TransactionAmount { get; set; }
        public DateTime DateOfSale { get; set; }
    }
}
