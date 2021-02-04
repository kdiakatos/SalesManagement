using SalesManagement.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalesManagement.DataLayer.Interfaces
{
    public interface ISellerRepository
    {
        Task<Seller> CreateSellerAsync(Seller seller);
        Task DeleteSellerAsync(Guid id);
        Task<List<Seller>> GetAllSellersAsync();
        Task<Seller> GetSellerByIdAsync(Guid id);
        Task<Seller> UpdateSellerAsync(Seller seller);
        Task<int> GetNumberOfSellers();
    }
}