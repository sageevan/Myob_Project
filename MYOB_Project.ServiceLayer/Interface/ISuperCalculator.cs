namespace MYOB_Project.ServiceLayer.Interface
{
    public interface ISuperCalculator
    {
        decimal Calculate(decimal grossIncome, decimal superRate);
    }
}
