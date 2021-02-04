using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SalesManagement.BusinessLayer.Models
{
    public class SaleModel
    {
        public Guid SaleId { get; set; }
        public SellerModel Seller { get; set; }
        [DisplayName("Seller Name")]
        [Required]
        public Guid SellerId { get; set; }

        [DisplayName("Transaction Amount")]
        [Required]
        public decimal TransactionAmount { get; set; }

        [DisplayName("Date Of Sale")]
        [Required]
        public DateTime DateOfSale { get; set; }
    }
}
