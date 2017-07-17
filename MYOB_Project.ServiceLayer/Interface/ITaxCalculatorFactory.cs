namespace MYOB_Project.ServiceLayer.Interface
{
    public interface ITaxCalculatorFactory
    {
        ITaxCalculatorStrategy CreateTaxCalculator(decimal annualIncome);
    }
}
