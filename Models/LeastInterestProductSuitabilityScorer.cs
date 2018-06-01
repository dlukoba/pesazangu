using System;
using System.Linq;
using System.Collections.Generic;

namespace pesazangu.Models
{
    public class LeastInterestProductSuitabilityScorer : IScoreProductSuitability
    {
        public List<ProductWithScore> Score(IEnumerable<Product> products, LoanConstraints constraints)
        {
            var fixedMatch = products
                .Where(c => c.LoanAmount.MinInclusive <= constraints.Amount)
                .Where(c => c.LoanAmount.MaxInclusive >= constraints.Amount)
                .Where(c => c.RepaymentPeriodInDays >= constraints.RepaymentPeriodInDays)
                .OrderBy(c => c.InterestRate);

            List<ProductWithScore> ordered = new List<ProductWithScore>();

            Product first = null;
            foreach (var prod in fixedMatch)
            {
                if (first == null)
                {
                    first = prod;
                }
                ordered.Add(new ProductWithScore(prod, (double)(prod.InterestRate / first.InterestRate)));
            }
            return ordered;
        }
    }
}