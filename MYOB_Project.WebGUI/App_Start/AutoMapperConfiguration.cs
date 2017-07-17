using AutoMapper;
using MYOB_Project.ServiceLayer.Messages;
using MYOB_Project.WebGUI.Models;

namespace MYOB_Project.WebGUI.App_Start
{
    public class AutoMapperConfiguration
    {
        public static void Config()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<EmployeePayslipRequestViewModel, EmployeeRequestMessage>();
                cfg.CreateMap<EmployeeResponseMessage, EmployeePayslipResponseViewModel>();
            });
        }
    }
}