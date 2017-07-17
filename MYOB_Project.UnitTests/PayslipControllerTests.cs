using AutoMapper;
using Moq;
using MYOB_Project.ServiceLayer;
using MYOB_Project.ServiceLayer.Interface;
using MYOB_Project.ServiceLayer.Messages;
using MYOB_Project.WebGUI.Controllers;
using MYOB_Project.WebGUI.Models;
using NUnit.Framework;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace MYOB_Project.UnitTests
{
    [TestFixture]
    public class PayslipControllerTests
    {
        private PayslipController sut;
        private Mock<IPayslipService> payslipService;

        [SetUp]
        public void Init()
        {
            payslipService = new Mock<IPayslipService>();
            sut = new PayslipController(payslipService.Object);

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<EmployeePayslipRequestViewModel, EmployeeRequestMessage>();
                cfg.CreateMap<EmployeeResponseMessage, EmployeePayslipResponseViewModel>();
            });
        }

        private string ConvertListToJson(List<SelectListItem> items)
        {
            return new JavaScriptSerializer().Serialize(items);
        }

        [Test]
        public void When_CreateActionCalled_Expect_DefaultCreateViewToBeCalled()
        {
            var result = sut.Create() as ViewResult;

            Assert.That(result.ViewName, Is.EqualTo(""));
        }

        [Test]
        public void When_CreateActionCalled_Expect_ViewBagMonthsToHave12MonthsValue()
        {
            var expected = ConvertListToJson(new List<SelectListItem>
                {
                    new SelectListItem{ Text="January", Value = "1" },
                    new SelectListItem{ Text="February", Value = "2" },
                    new SelectListItem{ Text="March", Value = "3" },
                    new SelectListItem{ Text="April", Value = "4" },
                    new SelectListItem{ Text="May", Value = "5" },
                    new SelectListItem{ Text="June", Value = "6" },
                    new SelectListItem{ Text="July", Value = "7" },
                    new SelectListItem{ Text="August", Value = "8" },
                    new SelectListItem{ Text="September", Value = "9" },
                    new SelectListItem{ Text="October", Value = "10" },
                    new SelectListItem{ Text="November", Value = "11" },
                    new SelectListItem{ Text="December", Value = "12" }
                });

            var result = sut.Create() as ViewResult;

            Assert.That(ConvertListToJson(result.ViewData["Months"] as List<SelectListItem>), Is.EqualTo(expected));
        }

        [Test]
        public void When_CreateActionCalled_Expect_ViewBarYearsToHave10YearsValue()
        {
            var expected = ConvertListToJson(new List<SelectListItem>
            {
                new SelectListItem{ Text="2017", Value = "2017" },
                new SelectListItem{ Text="2016", Value = "2016" },
                new SelectListItem{ Text="2015", Value = "2015" },
                new SelectListItem{ Text="2014", Value = "2014" },
                new SelectListItem{ Text="2013", Value = "2013" },
                new SelectListItem{ Text="2012", Value = "2012" },
                new SelectListItem{ Text="2011", Value = "2011" },
                new SelectListItem{ Text="2010", Value = "2010" },
                new SelectListItem{ Text="2009", Value = "2009" },
                new SelectListItem{ Text="2008", Value = "2008" }
            });

            var result = sut.Create() as ViewResult;

            Assert.That(ConvertListToJson(result.ViewData["Years"] as List<SelectListItem>), Is.EqualTo(expected));
        }

        [Test]
        public void When_HttpPostCreateActionCalled_Expect_PayslipServiceGeneratePayslipWasCalled()
        {
            payslipService.Setup(x => x.GeneratePayslip(It.IsAny<EmployeeRequestMessage>())).
                Returns(new EmployeeResponseMessage()
                {
                    FullName = "Sagee Pathma",
                    GrossIncome = 5000,
                    IncomeTax = 1000,
                    NetIncome = 4000,
                    Super = 450
                });

            var testData = new EmployeePayslipRequestViewModel()
            {
                FirstName = "Sagee",
                LastName = "Pathma",
                AnnualIncome = 60000,
                SuperRate = 8,
                Month = 2,
                Year = 2017
            };

            var result = sut.Create(testData) as ViewResult;

            payslipService.Verify(x => x.GeneratePayslip(It.IsAny<EmployeeRequestMessage>()), Times.Once());
        }

        [Test]
        public void When_HttpPostCreateActionCalled_Expect_DetailViewToBeCalled()
        {
            var testData = new EmployeePayslipRequestViewModel()
            {
                FirstName = "Sagee",
                LastName = "Pathma",
                AnnualIncome = 72000,
                SuperRate = 8,
                Month = 2,
                Year = 2017
            };

            var result = sut.Create(testData) as ViewResult;

            Assert.That(result.ViewName, Is.EqualTo("Detail"));
        }
    }
}
