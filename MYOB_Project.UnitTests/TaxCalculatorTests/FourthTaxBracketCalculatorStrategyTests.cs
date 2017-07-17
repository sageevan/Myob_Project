using MYOB_Project.ServiceLayer.Calculator.TaxCalculator;
using MYOB_Project.ServiceLayer.Interface;
using NUnit.Framework;

namespace MYOB_Project.UnitTests.TaxCalculatorTests
{
    [TestFixture]
    public class FourthTaxBracketCalculatorStrategyTests
    {
        public ITaxCalculatorStrategy sut;

        [SetUp]
        public void Init()
        {
            sut = new FourthTaxBracketCalculatorStrategy();
        }

        [Test]
        public void When_FourthTaxBracketCalculatorPassedWithLowerLimitValue_Expect_ReturnsTaxCalculatedOnTheFixedTaxableAmount()
        {
            var annualIncome = 80000;

            var result = sut.CalculateTax(annualIncome);

            Assert.That(result, Is.EqualTo(1462));
        }

        [Test]
        public void When_FourthTaxBracketCalculatorPassedWithNumberGreaterThanLowerLimit_Expect_ReturnsWholeNumber()
        {
            var annualIncome = 90000;

            var result = sut.CalculateTax(annualIncome);

            Assert.That(result, Is.EqualTo(1771));
        }

        [Test]
        public void When_FourthTaxBracketCalculatorResultHasDecimalLessThanFiftyCents_Expect_ReturnsWholeNumberRoundedDown()
        {
            var annualIncome = 110000;

            var result = sut.CalculateTax(annualIncome);

            Assert.That(result, Is.EqualTo(2387));
        }

        [Test]
        public void When_FourthTaxBracketCalculatorResultHasDecimalMoreThanFiftyCents_Expect_ReturnsWholeNumberRoundedToNextHigherNumber()
        {
            var annualIncome = 100000;

            var result = sut.CalculateTax(annualIncome);

            Assert.That(result, Is.EqualTo(2079));
        }

        [Test]
        public void When_FourthTaxBracketCalculatorResultHasDecimalExactlyFiftyCents_Expect_ReturnsWholeNumberRoundedToNextHigherNumber()
        {
            var annualIncome = 120000;

            var result = sut.CalculateTax(annualIncome);

            Assert.That(result, Is.EqualTo(2696));
        }
    }
}
