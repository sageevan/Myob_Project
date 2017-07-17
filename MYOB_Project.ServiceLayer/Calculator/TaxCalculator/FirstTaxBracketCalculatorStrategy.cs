using System;
using MYOB_Project.ServiceLayer.Interface;

namespace MYOB_Project.ServiceLayer.Calculator.TaxCalculator
{
    public class FirstTaxBracketCalculatorStrategy : ITaxCalculatorStrategy
    {
        public decimal CalculateTax(decimal annualIncome)
        {
            return 0;
        }
    }
}
