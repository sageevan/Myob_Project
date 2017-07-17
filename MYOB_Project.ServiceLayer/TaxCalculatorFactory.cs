using System;
using MYOB_Project.ServiceLayer.Interface;
using MYOB_Project.ServiceLayer.Calculator.TaxCalculator;

namespace MYOB_Project.ServiceLayer
{
    public class TaxCalculatorFactory : ITaxCalculatorFactory
    {
        private const decimal SECOND_TAX_BRACKET_LOWER_LIMIT = 18200M;
        private const decimal THIRD_TAX_BRACKET_LOWER_LIMIT = 37000M;
        private const decimal FOURTH_TAX_BRACKET_LOWER_LIMIT = 80000M;
        private const decimal FIFTH_TAX_BRACKET_LOWER_LIMIT = 180000M;

        public ITaxCalculatorStrategy CreateTaxCalculator(decimal annualIncome)
        {
            ITaxCalculatorStrategy taxCalculator = null;

            if (annualIncome > FIFTH_TAX_BRACKET_LOWER_LIMIT)
                taxCalculator = new FifthTaxBracketCalculatorStrategy();
            else if (annualIncome > FOURTH_TAX_BRACKET_LOWER_LIMIT)
                taxCalculator = new FourthTaxBracketCalculatorStrategy();
            else if (annualIncome > THIRD_TAX_BRACKET_LOWER_LIMIT)
                taxCalculator = new ThirdTaxBracketCalculatorStrategy();
            else if (annualIncome > SECOND_TAX_BRACKET_LOWER_LIMIT)
                taxCalculator = new SecondTaxBracketCalculatorStrategy();
            else
                taxCalculator = new FirstTaxBracketCalculatorStrategy();

            return taxCalculator;
        }
    }
}
