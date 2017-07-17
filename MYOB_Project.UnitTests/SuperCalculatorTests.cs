using MYOB_Project.ServiceLayer.Calculator;
using MYOB_Project.ServiceLayer.Interface;
using NUnit.Framework;

namespace MYOB_Project.UnitTests
{
    [TestFixture]
    public class SuperCalculatorTests
    {
        public ISuperCalculator sut;

        [SetUp]
        public void Init()
        {
            sut = new SuperCalculator();
        }

        [Test]
        public void When_SuperCalculatorPassedWithZeroValueForInput_Expect_ReturnsZero()
        {
            var grossIncome = 0;
            var superRate = 0;

            var result = sut.Calculate(grossIncome, superRate);

            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void When_SuperCalculatorResultHasNoDecimal_Expect_ReturnsWholeNumber()
        {
            var grossIncome = 5000;
            var superRate = 9;

            var result = sut.Calculate(grossIncome, superRate);

            Assert.That(result, Is.EqualTo(450));
        }

        [Test]
        public void When_SuperCalculatorResultHasDecimalLessThanFiftyCents_Expect_ReturnsWholeNumberRoundedDown()
        {
            var grossIncome = 5004;
            var superRate = 9;

            var result = sut.Calculate(grossIncome, superRate);

            Assert.That(result, Is.EqualTo(450));
        }

        [Test]
        public void When_SuperCalculatorResultHasDecimalMoreThanFiftyCents_Expect_ReturnsWholeNumberRoundedToNextHigherNumber()
        {
            var grossIncome = 5298;
            var superRate = 9;

            var result = sut.Calculate(grossIncome, superRate);

            Assert.That(result, Is.EqualTo(477));
        }

        [Test]
        public void When_SuperCalculatorResultHasDecimalExactlyFiftyCents_Expect_ReturnsWholeNumberRoundedToNextHigherNumber()
        {
            var grossIncome = 5005.56M;
            var superRate = 9;

            var result = sut.Calculate(grossIncome, superRate);

            Assert.That(result, Is.EqualTo(451));
        }
    }
}
