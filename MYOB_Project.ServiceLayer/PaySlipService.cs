using System;
using MYOB_Project.ServiceLayer.Interface;
using MYOB_Project.ServiceLayer.Messages;

namespace MYOB_Project.ServiceLayer
{
    public class PayslipService : IPayslipService
    {
        private IGrossIncomeCalculator grossIncomeCalculator;
        private IPayPeriodCalculator payPeriodCalculator;
        private ITaxCalculatorFactory taxCalculatorFactory;
        private INetIncomeCalculator netIncomeCalculator;
        private ISuperCalculator superCalculator;

        public PayslipService(IGrossIncomeCalculator grossIncomeCalculator,
        IPayPeriodCalculator payPeriodCalculator,
        ITaxCalculatorFactory taxCalculatorFactory,
        INetIncomeCalculator netIncomeCalculator,
        ISuperCalculator superCalculator)
        {
            this.grossIncomeCalculator = grossIncomeCalculator;
            this.payPeriodCalculator = payPeriodCalculator;
            this.taxCalculatorFactory = taxCalculatorFactory;
            this.netIncomeCalculator = netIncomeCalculator;
            this.superCalculator = superCalculator;
        }

        public EmployeeResponseMessage GeneratePayslip(EmployeeRequestMessage request)
        {
            EmployeeResponseMessage response = new EmployeeResponseMessage();
            response.FullName = $"{request.FirstName} {request.LastName}";
            response.PayPeriod = payPeriodCalculator.GetPayPeriod(request.Year, request.Month);
            response.GrossIncome = grossIncomeCalculator.Calculate(request.AnnualIncome);
            response.IncomeTax = GetIncomeTax(request.AnnualIncome);
            response.NetIncome = netIncomeCalculator.Calculate(response.GrossIncome, response.IncomeTax);
            response.Super = superCalculator.Calculate(response.GrossIncome, request.SuperRate);

            return response;
        }

        private decimal GetIncomeTax(decimal annualIncome)
        {
            ITaxCalculatorStrategy taxCalculator = taxCalculatorFactory.CreateTaxCalculator(annualIncome);
            return taxCalculator.CalculateTax(annualIncome);
        }
    }
}
