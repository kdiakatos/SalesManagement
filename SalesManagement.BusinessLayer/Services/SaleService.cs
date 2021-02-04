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
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IMapper _mapper;

        public SaleService(ISaleRepository saleRepository, IMapper mapper)
        {
            _saleRepository = saleRepository;
            _mapper = mapper;
        }

        public async Task<SaleModel> CreateSaleAsync(SaleModel sale)
        {
            var saleEntity = _mapper.Map<Sale>(sale);
            var result = await _saleRepository.CreateSaleAsync(saleEntity);
            sale = _mapper.Map<SaleModel>(result);
            return sale;
        }

        public async Task<SaleModel> UpdateSaleAsync(SaleModel sale)
        {
            var saleEntity = _mapper.Map<Sale>(sale);
            await _saleRepository.UpdateSaleAsync(saleEntity);
            return sale;
        }

        public async Task<SaleModel> GetSaleByIdAsync(Guid id)
        {
            var result = await _saleRepository.GetSaleByIdAsync(id);
            return _mapper.Map<SaleModel>(result);
        }

        public async Task DeleteSaleAsync(Guid id)
        {
            await _saleRepository.DeleteSaleAsync(id);
        }

        public async Task<List<SaleModel>> GetAllSalesAsync()
        {
            return _mapper.Map<List<SaleModel>>(await _saleRepository.GetAllSalesAsync());
        }

        public async Task<decimal> GellTotalSalesAmount()
        {
            var result = await GetAllSalesAsync();
            return result.Sum(a => a.TransactionAmount);
        }
    }
}
