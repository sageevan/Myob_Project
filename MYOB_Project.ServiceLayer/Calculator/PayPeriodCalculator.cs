using System;
using MYOB_Project.ServiceLayer.Interface;

namespace MYOB_Project.ServiceLayer.Calculator
{
    public class PayPeriodCalculator : IPayPeriodCalculator
    {
        public string GetPayPeriod(int year, int month)
        {
            DateTime startDateOfMonth = GetStartDateOfTheMonth(year, month);
            DateTime endDateOfMonth = GetEndDateOfTheMonth(year, month);

            return $"{startDateOfMonth:dd MMMM} - {endDateOfMonth:dd MMMM}";
        }

        private DateTime GetStartDateOfTheMonth(int year, int month)
        {
            return new DateTime(year, month, 1);
        }

        private DateTime GetEndDateOfTheMonth(int year, int month)
        {
            if (month <= 11)
                month++;
            else
            {
                month = 1;
                year++;
            }

            return new DateTime(year, month, 1).AddDays(-1);
        }
    }
}
