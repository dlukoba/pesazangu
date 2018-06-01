namespace pesazangu.Models
{
    public class CompareResultViewModel
    {
        public int VendorId { get; set; }
        public string VendorName { get; set; }
        public int ProductId { get; set; }
        public string ProductShortDesc { get; set; }
        public decimal LoanAmount { get; set; }
        public decimal RepayableAmount { get; set; }
        public double Score { get; set; }
        public int MaxRepaymentPeriodInDays { get; set; }
    }
}