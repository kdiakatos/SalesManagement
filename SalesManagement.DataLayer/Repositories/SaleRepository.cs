using Microsoft.EntityFrameworkCore;
using SalesManagement.DataLayer.Entities;
using SalesManagement.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesManagement.DataLayer.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly SalesManagementContext _salesManagementContext;

        public SaleRepository(SalesManagementContext salesManagementContext)
        {
            _salesManagementContext = salesManagementContext;
        }

        public async Task<Sale> CreateSaleAsync(Sale sale)
        {
            await _salesManagementContext.AddAsync(sale);
            await _salesManagementContext.SaveChangesAsync();
            return sale;
        }

        public async Task<Sale> UpdateSaleAsync(Sale sale)
        {
            var dbRecord = await _salesManagementContext.Sales.FirstOrDefaultAsync(x => x.SaleId == sale.SaleId);
            if (dbRecord != null)
            {
                dbRecord.TransactionAmount = sale.TransactionAmount;
                dbRecord.DateOfSale = sale.DateOfSale;
                await _salesManagementContext.SaveChangesAsync();
            }
            return sale;
        }

        public async Task<Sale> GetSaleByIdAsync(Guid id)
        {
            return await _salesManagementContext.Sales.Include(x => x.Seller).FirstOrDefaultAsync(x => x.SaleId == id);
        }

        public async Task DeleteSaleAsync(Guid id)
        {
            var dbRecord = await _salesManagementContext.Sales.FirstOrDefaultAsync(x => x.SaleId == id);
            _salesManagementContext.Remove(dbRecord);
            await _salesManagementContext.SaveChangesAsync();
        }

        public async Task<List<Sale>> GetAllSalesAsync()
        {
            return await _salesManagementContext.Sales.Include(x => x.Seller).ToListAsync();
        }

        public async Task<List<Sale>> GetAllSalesBySellerIdAsync(Guid id)
        {
            return await _salesManagementContext.Sales.Include(x => x.Seller).Where(x => x.SellerId == id).ToListAsync();
        }
    }
}
