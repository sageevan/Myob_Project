namespace MYOB_Project.ServiceLayer.Messages
{
    public class EmployeeRequestMessage
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal AnnualIncome { get; set; }
        public decimal SuperRate { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
    }
}
