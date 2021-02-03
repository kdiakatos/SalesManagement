using AutoMapper;
using SalesManagement.BusinessLayer.Interfaces;
using SalesManagement.BusinessLayer.Models;
using SalesManagement.DataLayer.Entities;
using SalesManagement.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
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
                item.Commision = (sales.Sum(a => a.TransactionAmount) * 10) / 100; //TODO
            }
            return sellersList;
        }
    }
}
