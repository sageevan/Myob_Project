using System;
using MYOB_Project.ServiceLayer.Interface;

namespace MYOB_Project.ServiceLayer.Calculator.TaxCalculator
{
    public class SecondTaxBracketCalculatorStrategy : ITaxCalculatorStrategy
    {
        private const decimal LOWER_LIMIT = 18200M;
        private const decimal TAXABLE_AMOUNT_PER_DOLLAR = 0.19M;

        public decimal CalculateTax(decimal annualIncome)
        {
            decimal incomeTax = ((annualIncome - LOWER_LIMIT) * TAXABLE_AMOUNT_PER_DOLLAR) / 12;

            return Math.Round(incomeTax, MidpointRounding.AwayFromZero);
        }
    }
}
