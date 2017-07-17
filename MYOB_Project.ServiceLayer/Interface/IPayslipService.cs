using MYOB_Project.ServiceLayer.Messages;

namespace MYOB_Project.ServiceLayer.Interface
{
    public interface IPayslipService
    {
        EmployeeResponseMessage GeneratePayslip(EmployeeRequestMessage request);
    }
}
