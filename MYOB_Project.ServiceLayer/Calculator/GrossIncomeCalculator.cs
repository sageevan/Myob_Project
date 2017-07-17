using System;
using MYOB_Project.ServiceLayer.Interface;

namespace MYOB_Project.ServiceLayer.Calculator
{
    public class GrossIncomeCalculator : IGrossIncomeCalculator
    {
        public decimal Calculate(decimal annualIncome)
        {
            return Math.Round(annualIncome / 12, MidpointRounding.AwayFromZero);
        }
    }
}
