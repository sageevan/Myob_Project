using MYOB_Project.ServiceLayer.Calculator.TaxCalculator;
using MYOB_Project.ServiceLayer.Interface;
using NUnit.Framework;

namespace MYOB_Project.UnitTests.TaxCalculatorTests
{
    [TestFixture]
    public class FifthTaxBracketCalculatorStrategyTests
    {
        public ITaxCalculatorStrategy sut;

        [SetUp]
        public void Init()
        {
            sut = new FifthTaxBracketCalculatorStrategy();
        }

        [Test]
        public void When_FifthTaxBracketCalculatorPassedWithLowerLimitValue_Expect_ReturnsTaxCalculatedOnTheFixedTaxableAmount()
        {
            var annualIncome = 180000;

            var result = sut.CalculateTax(annualIncome);

            Assert.That(result, Is.EqualTo(4546));
        }

        [Test]
        public void When_FifthTaxBracketCalculatorPassedWithNumberGreaterThanLowerLimit_Expect_ReturnsWholeNumber()
        {
            var annualIncome = 220000;

            var result = sut.CalculateTax(annualIncome);

            Assert.That(result, Is.EqualTo(6046));
        }

        [Test]
        public void When_FifthTaxBracketCalculatorResultHasDecimalLessThanFiftyCents_Expect_ReturnsWholeNumberRoundedDown()
        {
            var annualIncome = 215000;

            var result = sut.CalculateTax(annualIncome);

            Assert.That(result, Is.EqualTo(5858));
        }

        [Test]
        public void When_FifthTaxBracketCalculatorResultHasDecimalMoreThanFiftyCents_Expect_ReturnsWholeNumberRoundedToNextHigherNumber()
        {
            var annualIncome = 255555;

            var result = sut.CalculateTax(annualIncome);

            Assert.That(result, Is.EqualTo(7379));
        }

        [Test]
        public void When_FifthTaxBracketCalculatorResultHasDecimalExactlyFiftyCents_Expect_ReturnsWholeNumberRoundedToNextHigherNumber()
        {
            var annualIncome = 190000;

            var result = sut.CalculateTax(annualIncome);

            Assert.That(result, Is.EqualTo(4921));
        }
    }
}
