using SalesManagement.BusinessLayer.Models;
using System.Threading.Tasks;

namespace SalesManagement.BusinessLayer.Interfaces
{
    public interface IStatisticService
    {
        Task<StatisticModel> GetTotalsAsync();
    }
}
