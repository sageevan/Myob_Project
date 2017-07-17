using AutoMapper;
using MYOB_Project.ServiceLayer.Interface;
using MYOB_Project.ServiceLayer.Messages;
using MYOB_Project.WebGUI.Models;
using System.Web.Mvc;

namespace MYOB_Project.WebGUI.Controllers
{
    public class PayslipController : Controller
    {
        private IPayslipService payService;

        public PayslipController(IPayslipService payService)
        {
            this.payService = payService;
        }

        public ActionResult Create()
        {
            ViewBag.Months = DropDownListUtil.GetMonths();
            ViewBag.Years = DropDownListUtil.GetYears();

            return View();
        }

        [HttpPost]
        public ActionResult Create(EmployeePayslipRequestViewModel model)
        {
            EmployeePayslipResponseViewModel responseModel = new EmployeePayslipResponseViewModel();

            if (ModelState.IsValid)
            {
                EmployeeRequestMessage request = Mapper.Map<EmployeeRequestMessage>(model);

                EmployeeResponseMessage response = payService.GeneratePayslip(request);
                responseModel = Mapper.Map<EmployeePayslipResponseViewModel>(response);
            }

            return View("Detail", responseModel);
        }

    }
}