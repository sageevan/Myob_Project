using Moq;
using MYOB_Project.ServiceLayer;
using MYOB_Project.ServiceLayer.Calculator.TaxCalculator;
using MYOB_Project.ServiceLayer.Interface;
using MYOB_Project.ServiceLayer.Messages;
using NUnit.Framework;

namespace MYOB_Project.UnitTests
{
    [TestFixture]
    public class PayslipServiceTests
    {
        public IPayslipService sut;
        EmployeeRequestMessage request;

        Mock<IGrossIncomeCalculator> grossIncomeCalculator;
        Mock<IPayPeriodCalculator> payPeriodCalculator;
        Mock<ITaxCalculatorFactory> taxCalculatorFactory;
        Mock<INetIncomeCalculator> netIncomeCalculator;
        Mock<ISuperCalculator> superCalculator;

        [SetUp]
        public void Init()
        {
            grossIncomeCalculator = new Mock<IGrossIncomeCalculator>();
            payPeriodCalculator = new Mock<IPayPeriodCalculator>();
            taxCalculatorFactory = new Mock<ITaxCalculatorFactory>();
            netIncomeCalculator = new Mock<INetIncomeCalculator>();
            superCalculator = new Mock<ISuperCalculator>();

            grossIncomeCalculator.Setup(x => x.Calculate(It.IsAny<decimal>())).Returns(5004);
            payPeriodCalculator.Setup(x => x.GetPayPeriod(It.IsAny<int>(), It.IsAny<int>())).Returns("01 January - 31 January");
            taxCalculatorFactory.Setup(x => x.CreateTaxCalculator(It.IsAny<decimal>())).Returns(new SecondTaxBracketCalculatorStrategy());
            netIncomeCalculator.Setup(x => x.Calculate(It.IsAny<decimal>(), It.IsAny<decimal>())).Returns(4000);
            superCalculator.Setup(x => x.Calculate(It.IsAny<decimal>(), It.IsAny<decimal>())).Returns(500);

            sut = new PayslipService(grossIncomeCalculator.Object,
                payPeriodCalculator.Object,
                taxCalculatorFactory.Object,
                netIncomeCalculator.Object,
                superCalculator.Object);

            request = new EmployeeRequestMessage()
            {
                FirstName = "Sagee",
                LastName = "Pathma",
                AnnualIncome = 65000,
                SuperRate = 9,
                Month = 1,
                Year = 2017
            };
        }


        [Test]
        public void When_GeneratePayslipWasCalled_Expect_ReturnsFullNameWithFirstNameFollowedByLastNameAndSpaceInBetween()
        {
            var result = sut.GeneratePayslip(request);

            Assert.That(result.FullName, Is.EqualTo("Sagee Pathma"));
        }

        [Test]
        public void When_GeneratePayslipWasCalled_Expect_GrossIncomeCalculatorCalculateWasCalled()
        {
            var result = sut.GeneratePayslip(request);

            grossIncomeCalculator.Verify(x => x.Calculate(It.IsAny<decimal>()), Times.Once());
        }

        [Test]
        public void When_GeneratePayslipWasCalled_Expect_PayPeriodCalculatorGetPayPeriodWasCalled()
        {
            var result = sut.GeneratePayslip(request);

            payPeriodCalculator.Verify(x => x.GetPayPeriod(It.IsAny<int>(), It.IsAny<int>()), Times.Once());
        }

        [Test]
        public void When_GeneratePayslipWasCalled_Expect_NetIncomeCalculatorCalculateWasCalled()
        {
            var result = sut.GeneratePayslip(request);

            netIncomeCalculator.Verify(x => x.Calculate(It.IsAny<decimal>(), It.IsAny<decimal>()), Times.Once());
        }

        [Test]
        public void When_GeneratePayslipWasCalled_Expect_SuperCalculatorCalculateWasCalled()
        {
            var result = sut.GeneratePayslip(request);

            superCalculator.Verify(x => x.Calculate(It.IsAny<decimal>(), It.IsAny<decimal>()), Times.Once());
        }

    }
}
