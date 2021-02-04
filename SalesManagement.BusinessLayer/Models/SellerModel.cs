using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SalesManagement.BusinessLayer.Models
{
    public class SellerModel
    {
        public Guid SellerId { get; set; }
        [DisplayName("First Name")]
        [Required]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        [Required]
        public string LastName { get; set; }
        [DisplayName("Full Name")]
        [Required]
        public string FullName => $"{FirstName} {LastName}";
        public ICollection<SaleModel> Sales { get; set; }
        public decimal Commission { get; set; }
    }
}
