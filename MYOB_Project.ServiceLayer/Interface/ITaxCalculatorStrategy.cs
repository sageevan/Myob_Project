
namespace MYOB_Project.ServiceLayer.Interface
{
    public interface ITaxCalculatorStrategy
    {
        decimal CalculateTax(decimal annualIncome);
    }
}
