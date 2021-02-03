using Microsoft.EntityFrameworkCore;
using SalesManagement.DataLayer.Entities;
using System;

namespace SalesManagement.DataLayer
{
    public class SalesManagementContext : DbContext
    {
        public SalesManagementContext(DbContextOptions<SalesManagementContext> options) : base(options)
        {
        }

        public DbSet<Sale> Sales { get; set; }
        public DbSet<Seller> Sellers { get; set; }
    }
}
