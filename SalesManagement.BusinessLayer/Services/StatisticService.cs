using SalesManagement.BusinessLayer.Interfaces;
using SalesManagement.BusinessLayer.Models;
using System.Threading.Tasks;

namespace SalesManagement.BusinessLayer.Services
{
    public class StatisticService : IStatisticService
    {
        private readonly ISaleService _saleService;
        private readonly ISellerService _sellerService;

        public StatisticService(ISaleService saleService, ISellerService sellerService)
        {
            _saleService = saleService;
            _sellerService = sellerService;
        }

        public async Task<StatisticModel> GetTotalsAsync()
        {
            var totals = new StatisticModel
            {
                TotalSellers = await _sellerService.GetNumberOfSellers(),
                TotalSales = await _saleService.GellTotalSalesAmount()
            };
            return totals;
        }
    }
}
