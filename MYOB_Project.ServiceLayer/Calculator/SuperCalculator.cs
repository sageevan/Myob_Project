using System;
using MYOB_Project.ServiceLayer.Interface;

namespace MYOB_Project.ServiceLayer.Calculator
{
    public class SuperCalculator : ISuperCalculator
    {
        public decimal Calculate(decimal grossIncome, decimal superRate)
        {
            return Math.Round(grossIncome * superRate / 100, MidpointRounding.AwayFromZero);
        }
    }
}
