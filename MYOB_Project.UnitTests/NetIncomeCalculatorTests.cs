using MYOB_Project.ServiceLayer.Calculator;
using MYOB_Project.ServiceLayer.Interface;
using NUnit.Framework;

namespace MYOB_Project.UnitTests
{
    [TestFixture]
    public class NetIncomeCalculatorTests
    {
        public INetIncomeCalculator sut;

        [SetUp]
        public void Init()
        {
            sut = new NetIncomeCalculator();
        }

        [Test]
        public void When_NetIncomeCalculatorPassedWithZeroValueForInput_Expect_ReturnsZero()
        {
            var grossIncome = 0;
            var incomeTax = 0;

            var result = sut.Calculate(grossIncome, incomeTax);

            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void When_NetIncomeCalculatorPassedWithWholeNumberAsInput_Expect_ReturnsWholeNumber()
        {
            var grossIncome = 5000;
            var incomeTax = 1000;

            var result = sut.Calculate(grossIncome, incomeTax);

            Assert.That(result, Is.EqualTo(4000));
        }

        [Test]
        public void When_NetIncomeCalculatorResultHasDecimalLessThanFiftyCents_Expect_ReturnsWholeNumberRoundedDown()
        {
            var grossIncome = 5000.15M;
            var incomeTax = 1000;

            var result = sut.Calculate(grossIncome, incomeTax);

            Assert.That(result, Is.EqualTo(4000));
        }

        [Test]
        public void When_NetIncomeCalculatorResultHasDecimalMoreThanFiftyCents_Expect_ReturnsWholeNumberRoundedToNextHigherNumber()
        {
            var grossIncome = 5000.95M;
            var incomeTax = 1000;

            var result = sut.Calculate(grossIncome, incomeTax);

            Assert.That(result, Is.EqualTo(4001));
        }

        [Test]
        public void When_NetIncomeCalculatorResultHasDecimalExactlyFiftyCents_Expect_ReturnsWholeNumberRoundedToNextHigherNumber()
        {
            var grossIncome = 5000.5M;
            var incomeTax = 1000;

            var result = sut.Calculate(grossIncome, incomeTax);

            Assert.That(result, Is.EqualTo(4001));
        }

    }
}
