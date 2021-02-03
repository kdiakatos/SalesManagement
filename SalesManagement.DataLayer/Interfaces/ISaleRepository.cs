using SalesManagement.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalesManagement.DataLayer.Interfaces
{
    public interface ISaleRepository
    {
        Task<Sale> CreateSaleAsync(Sale sale);
        Task DeleteSaleAsync(Guid id);
        Task<List<Sale>> GetAllSalesAsync();
        Task<Sale> GetSaleByIdAsync(Guid id);
        Task<Sale> UpdateSaleAsync(Sale sale);

        Task<List<Sale>> GetAllSalesBySellerIdAsync(Guid id);
    }
}