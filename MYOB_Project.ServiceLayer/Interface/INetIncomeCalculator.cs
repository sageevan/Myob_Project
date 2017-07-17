namespace MYOB_Project.ServiceLayer.Interface
{
    public interface INetIncomeCalculator
    {
        decimal Calculate(decimal grossIncome, decimal incomeTax);
    }
}
