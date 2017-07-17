namespace MYOB_Project.ServiceLayer.Interface
{
    public interface IGrossIncomeCalculator
    {
        decimal Calculate(decimal annualIncome);
    }
}
