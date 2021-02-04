using AutoMapper;
using SalesManagement.BusinessLayer.Interfaces;
using SalesManagement.BusinessLayer.Models;
using SalesManagement.DataLayer.Entities;
using SalesManagement.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace SalesManagement.BusinessLayer.Services
{
    public class SellerService : ISellerService
    {
        private readonly ISellerRepository _sellerRepository;
        private readonly IMapper _mapper;

        public SellerService(ISellerRepository sellerRepository, IMapper mapper)
        {
            _sellerRepository = sellerRepository;
            _mapper = mapper;
        }

        public async Task<SellerModel> CreateSellerAsync(SellerModel seller)
        {
            var sellerEntity = _mapper.Map<Seller>(seller);
            var result = await _sellerRepository.CreateSellerAsync(sellerEntity);
            seller = _mapper.Map<SellerModel>(result);
            return seller;
        }

        public async Task<SellerModel> UpdateSellerAsync(SellerModel seller)
        {
            var sellerEntity = _mapper.Map<Seller>(seller);
            await _sellerRepository.UpdateSellerAsync(sellerEntity);
            return seller;
        }

        public async Task<SellerModel> GetSellerByIdAsync(Guid id)
        {
            var result = await _sellerRepository.GetSellerByIdAsync(id);
            return _mapper.Map<SellerModel>(result);
        }

        public async Task DeleteSellerAsync(Guid id)
        {
            await _sellerRepository.DeleteSellerAsync(id);
        }

        public async Task<List<SellerModel>> GetAllSellersAsync()
        {
            var response = await _sellerRepository.GetAllSellersAsync();
            var sellersList = _mapper.Map<List<SellerModel>>(response);
            foreach (var item in sellersList)
            {
                var sales = response.FirstOrDefault(a => a.SellerId == item.SellerId).Sales.ToList();
                item.Commission = (sales.Sum(a => a.TransactionAmount) * 10) / 100; //TODO
            }
            return sellersList;
        }

        public async Task<int> GetNumberOfSellers()
        {
            return await _sellerRepository.GetNumberOfSellers();
        }

        public async Task<List<SellerStatisticModel>> GetSellerMonthlyStatisticsAsync(Guid id)
        {
            var result = await _sellerRepository.GetSellerByIdAsync(id);
            var seller = _mapper.Map<SellerModel>(result);
            var monthlyStatistics = seller.Sales.Select(k => new { k.DateOfSale.Year, k.DateOfSale.Month, k.TransactionAmount })
                                .GroupBy(x => new { x.Year, x.Month }, (key, group) => new SellerStatisticModel
                                {
                                    MonthName = new DateTime(key.Year, key.Month, 1).ToString("MMMM", CultureInfo.InvariantCulture),
                                    Year = key.Year,
                                    MonthlySales = group.Sum(k => k.TransactionAmount),
                                    MonthlyCommisions = (group.Sum(k => k.TransactionAmount) * 10 / 100)
                                }).ToList();
            return monthlyStatistics;
        }
    }
}
