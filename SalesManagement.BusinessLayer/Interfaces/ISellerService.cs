using SalesManagement.BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalesManagement.BusinessLayer.Interfaces
{
    public interface ISellerService
    {
        Task<SellerModel> CreateSellerAsync(SellerModel seller);
        Task DeleteSellerAsync(Guid id);
        Task<List<SellerModel>> GetAllSellersAsync();
        Task<SellerModel> GetSellerByIdAsync(Guid id);
        Task<SellerModel> UpdateSellerAsync(SellerModel seller);
    }
}