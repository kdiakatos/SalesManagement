using System;
using System.Collections.Generic;
using System.Text;

namespace SalesManagement.DataLayer.Entities
{
    public class Seller
    {
        public Guid SellerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Sale> Sales { get; set; }
    }
}
