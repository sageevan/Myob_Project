using MYOB_Project.ServiceLayer.Calculator.TaxCalculator;
using MYOB_Project.ServiceLayer.Interface;
using NUnit.Framework;

namespace MYOB_Project.UnitTests.TaxCalculatorTests
{
    [TestFixture]
    public class SecondTaxBracketCalculatorStrategyTests
    {
        public ITaxCalculatorStrategy sut;

        [SetUp]
        public void Init()
        {
            sut = new SecondTaxBracketCalculatorStrategy();
        }

        [Test]
        public void When_SecondTaxBracketCalculatorPassedWithLowerLimitValue_Expect_ReturnsZero()
        {
            var annualIncome = 18200;

            var result = sut.CalculateTax(annualIncome);

            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void When_SecondTaxBracketCalculatorPassedWithNumberGreaterThanLowerLimit_Expect_ReturnsWholeNumber()
        {
            var annualIncome = 35000;

            var result = sut.CalculateTax(annualIncome);

            Assert.That(result, Is.EqualTo(266));
        }

        [Test]
        public void When_SecondTaxBracketCalculatorResultHasDecimalLessThanFiftyCents_Expect_ReturnsWholeNumberRoundedDown()
        {
            var annualIncome = 33000;

            var result = sut.CalculateTax(annualIncome);

            Assert.That(result, Is.EqualTo(234));
        }

        [Test]
        public void When_SecondTaxBracketCalculatorResultHasDecimalMoreThanFiftyCents_Expect_ReturnsWholeNumberRoundedToNextHigherNumber()
        {
            var annualIncome = 36000;

            var result = sut.CalculateTax(annualIncome);

            Assert.That(result, Is.EqualTo(282));
        }

        [Test]
        public void When_SecondTaxBracketCalculatorResultHasDecimalExactlyFiftyCents_Expect_ReturnsWholeNumberRoundedToNextHigherNumber()
        {
            var annualIncome = 32000;

            var result = sut.CalculateTax(annualIncome);

            Assert.That(result, Is.EqualTo(219));
        }
    }
}
