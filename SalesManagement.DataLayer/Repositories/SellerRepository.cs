using Microsoft.EntityFrameworkCore;
using SalesManagement.DataLayer.Entities;
using SalesManagement.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalesManagement.DataLayer.Repositories
{
    public class SellerRepository : ISellerRepository
    {
        private readonly SalesManagementContext _salesManagementContext;

        public SellerRepository(SalesManagementContext salesManagementContext)
        {
            _salesManagementContext = salesManagementContext;
        }

        public async Task<Seller> CreateSellerAsync(Seller seller)
        {
            await _salesManagementContext.AddAsync(seller);
            await _salesManagementContext.SaveChangesAsync();
            return seller;
        }

        public async Task<Seller> UpdateSellerAsync(Seller seller)
        {
            var dbRecord = await _salesManagementContext.Sellers.FirstOrDefaultAsync(x => x.SellerId == seller.SellerId);
            if (dbRecord != null)
            {
                dbRecord.FirstName = seller.FirstName;
                dbRecord.LastName = seller.LastName;
                await _salesManagementContext.SaveChangesAsync();
            }
            return seller;
        }

        public async Task<Seller> GetSellerByIdAsync(Guid id)
        {
            return await _salesManagementContext.Sellers.Include(x => x.Sales).FirstOrDefaultAsync(x => x.SellerId == id);
        }

        public async Task DeleteSellerAsync(Guid id)
        {
            var dbRecord = await _salesManagementContext.Sellers.FirstOrDefaultAsync(x => x.SellerId == id);
            _salesManagementContext.Remove(dbRecord);
            await _salesManagementContext.SaveChangesAsync();
        }

        public async Task<List<Seller>> GetAllSellersAsync()
        {
            return await _salesManagementContext.Sellers.Include(x => x.Sales).ToListAsync();
        }
    }
}
