using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pesazangu.Models
{
    public interface IRepository
    {
        IEnumerable<Vendor> Vendors { get; }

        IEnumerable<Product> Products { get; }
    }

    public class InMemoryRepository : IRepository
    {
        public IEnumerable<Vendor> Vendors { get; } = new List<Vendor>()
        {
            new Vendor()
            {
                Id = 1,
                Name = "Tala",
                Products = new List<Product>()
                {
                    new Product() { Id = 1, VendorId = 1, InterestRate = 0.11M, LoanAmount= new Range<decimal>(100M, 200000M), ShortDesc = "Tala 21 day facility 11%", LongDesc = "Tala 21 day facility @ 11%", RepaymentPeriodInDays = 21 },
                    new Product() { Id = 2, VendorId = 1, InterestRate = 0.15M, LoanAmount = new Range<decimal>(100M, 20000M), ShortDesc = "Tala 30 day facility 15%", LongDesc = "Tala 30 day facility @ 15%", RepaymentPeriodInDays = 30 }
                }
            },
            new Vendor()
            {
                Id = 2,
                Name = "M-Shwari",
                Products = new List<Product>()
                {
                    new Product() { Id = 3, InterestRate = 0.075M, VendorId = 2, LoanAmount = new Range<decimal>(100M, 200000M), LongDesc = "M-Shwari Loan", RepaymentPeriodInDays = 30, ShortDesc = "M-Shwari Loan" }
                }
            },
            new Vendor()
            {
                Id = 3,
                Name = "Branch",
                Products = new List<Product>()
                {
                    new Product() { Id = 4, InterestRate = 0.1336M, VendorId = 3, LoanAmount = new Range<decimal>(100M, 200000M), LongDesc = "Branch loan", ShortDesc = "Branch loan @ 13.36%", RepaymentPeriodInDays = 30 }
                }
            }
        };

        public IEnumerable<Product> Products => Vendors.SelectMany(c => c.Products);
    }
}
