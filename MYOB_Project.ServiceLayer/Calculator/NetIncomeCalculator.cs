using System;
using MYOB_Project.ServiceLayer.Interface;

namespace MYOB_Project.ServiceLayer.Calculator
{
    public class NetIncomeCalculator : INetIncomeCalculator
    {
        public decimal Calculate(decimal grossIncome, decimal incomeTax)
        {
            return Math.Round(grossIncome - incomeTax, MidpointRounding.AwayFromZero);
        }
    }
}
