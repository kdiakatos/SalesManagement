namespace SalesManagement.BusinessLayer.Models
{
    public class SellerStatisticModel
    {
        public string MonthName { get; set; }
        public int Year { get; set; }
        public decimal MonthlySales { get; set; }
        public decimal MonthlyCommisions { get; set; }
    }
}
