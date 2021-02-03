using SalesManagement.BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalesManagement.BusinessLayer.Interfaces
{
    public interface ISaleService
    {
        Task<SaleModel> CreateSaleAsync(SaleModel sale);
        Task DeleteSaleAsync(Guid id);
        Task<List<SaleModel>> GetAllSalesAsync();
        Task<SaleModel> GetSaleByIdAsync(Guid id);
        Task<SaleModel> UpdateSaleAsync(SaleModel sale);
    }
}