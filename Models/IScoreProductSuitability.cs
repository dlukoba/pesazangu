using System;
using System.Collections.Generic;

namespace pesazangu.Models
{
    public interface IScoreProductSuitability
    {
        List<ProductWithScore> Score(IEnumerable<Product> products, LoanConstraints constraints);
    }

    public class LoanConstraints
    {
        public decimal Amount { get; set; }
        public int RepaymentPeriodInDays { get; set; }
    }

    public struct ProductWithScore
    {
        public Product Product { get; }
        public double Score { get; }

        public ProductWithScore(Product product, double score)
        {
            Product = product ?? throw new ArgumentNullException(nameof(product));
            Score = score;
        }
    }

    public class ProductWithScoreComparer : IComparer<ProductWithScore>
    {
        public int Compare(ProductWithScore a, ProductWithScore b)
            => a.Score.CompareTo(b.Score);

        public bool Equals(ProductWithScore a, ProductWithScore b)
            => a.Product.Id == b.Product.Id && Math.Abs(a.Score - b.Score) < 0.01;

        public int GetHashCode(ProductWithScore x)
            => x.Product.Id.GetHashCode();
    }
}