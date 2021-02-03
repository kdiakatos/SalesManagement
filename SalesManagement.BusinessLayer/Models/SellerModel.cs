using System;
using System.Collections.Generic;

namespace SalesManagement.BusinessLayer.Models
{
    public class SellerModel
    {
        public Guid SellerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public ICollection<SaleModel> Sales { get; set; }
        public decimal Commision { get; set; }
    }
}
