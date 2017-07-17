using MYOB_Project.ServiceLayer.Calculator.TaxCalculator;
using MYOB_Project.ServiceLayer.Interface;
using NUnit.Framework;

namespace MYOB_Project.UnitTests.TaxCalculatorTests
{
    [TestFixture]
    public class ThirdTaxBracketCalculatorStrategyTests
    {
        public ITaxCalculatorStrategy sut;

        [SetUp]
        public void Init()
        {
            sut = new ThirdTaxBracketCalculatorStrategy();
        }

        [Test]
        public void When_ThirdTaxBracketCalculatorPassedWithLowerLimitValue_Expect_ReturnsTaxCalculatedOnTheFixedTaxableAmount()
        {
            var annualIncome = 37000;

            var result = sut.CalculateTax(annualIncome);

            Assert.That(result, Is.EqualTo(298));
        }

        [Test]
        public void When_ThirdTaxBracketCalculatorPassedWithNumberGreaterThanLowerLimit_Expect_ReturnsWholeNumber()
        {
            var annualIncome = 65000;

            var result = sut.CalculateTax(annualIncome);

            Assert.That(result, Is.EqualTo(1056));
        }

        [Test]
        public void When_ThirdTaxBracketCalculatorResultHasDecimalLessThanFiftyCents_Expect_ReturnsWholeNumberRoundedDown()
        {
            var annualIncome = 66000;

            var result = sut.CalculateTax(annualIncome);

            Assert.That(result, Is.EqualTo(1083));
        }

        [Test]
        public void When_ThirdTaxBracketCalculatorResultHasDecimalMoreThanFiftyCents_Expect_ReturnsWholeNumberRoundedToNextHigherNumber()
        {
            var annualIncome = 75000;

            var result = sut.CalculateTax(annualIncome);

            Assert.That(result, Is.EqualTo(1327));
        }

        [Test]
        public void When_ThirdTaxBracketCalculatorResultHasDecimalExactlyFiftyCents_Expect_ReturnsWholeNumberRoundedToNextHigherNumber()
        {
            var annualIncome = 60000;

            var result = sut.CalculateTax(annualIncome);

            Assert.That(result, Is.EqualTo(921));
        }

    }
}
