using MYOB_Project.ServiceLayer.Interface;
using System;

namespace MYOB_Project.ServiceLayer.Calculator.TaxCalculator
{
    public class ThirdTaxBracketCalculatorStrategy : ITaxCalculatorStrategy
    {
        private const decimal LOWER_LIMIT = 37000M;
        private const decimal TAXABLE_AMOUNT_PER_DOLLAR = 0.325M;
        private const decimal TAXABLE_AMOUNT_FIXED = 3572M;

        public decimal CalculateTax(decimal annualIncome)
        {
            decimal incomeTax = (TAXABLE_AMOUNT_FIXED + (annualIncome - LOWER_LIMIT) * TAXABLE_AMOUNT_PER_DOLLAR) / 12;

            return Math.Round(incomeTax, MidpointRounding.AwayFromZero);
        }
    }
}
