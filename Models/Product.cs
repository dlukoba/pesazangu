using System;
using System.Collections.Generic;

namespace pesazangu.Models
{
    public class Product
    {
        public int Id { get; set; }

        public int VendorId { get; set; }

        public string ShortDesc { get; set; }

        public string LongDesc { get; set; }

        public Range<decimal> LoanAmount { get; set; }

        public decimal InterestRate { get; set; }

        public int RepaymentPeriodInDays { get; set; }

        public decimal GetRepayableAmount(decimal amount)
            => InterestRate * amount + amount; //ignore validation for now
    }

    public class Range<T> where T : IComparable
    {
        public T MinInclusive { get; }
        public T MaxInclusive { get; }

        public Range(T minInclusive, T maxInclusive)
        {
            MinInclusive = minInclusive;
            MaxInclusive = maxInclusive;
        }

        public static Range<T> Of(T minInclusive, T maxInclusive)
            => new Range<T>(minInclusive, maxInclusive);
    }
}