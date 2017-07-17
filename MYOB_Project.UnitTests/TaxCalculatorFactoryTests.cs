using MYOB_Project.ServiceLayer;
using MYOB_Project.ServiceLayer.Calculator.TaxCalculator;
using MYOB_Project.ServiceLayer.Interface;
using NUnit.Framework;

namespace MYOB_Project.UnitTests
{
    [TestFixture]
    public class TaxCalculatorFactoryTests
    {
        public ITaxCalculatorFactory sut;

        [SetUp]
        public void Init()
        {
            sut = new TaxCalculatorFactory();
        }

        [Test]
        public void When_AnnualIncomeIsLessThanFirstTaxBracketUpperLimit_Returns_FirstTaxBracketCalculator()
        {
            var annualIncome = 10000;

            var result = sut.CreateTaxCalculator(annualIncome);

            Assert.That(result, Is.TypeOf<FirstTaxBracketCalculatorStrategy>());
        }

        [Test]
        public void When_AnnualIncomeIsLessThanSecondTaxBracketUpperLimitButGreaterThanFirstTaxBracket_Returns_SecondTaxBracketCalculator()
        {
            var annualIncome = 25000;

            var result = sut.CreateTaxCalculator(annualIncome);

            Assert.That(result, Is.TypeOf<SecondTaxBracketCalculatorStrategy>());
        }

        [Test]
        public void When_AnnualIncomeIsLessThanThirdTaxBracketUpperLimitButGreaterThanSecondTaxBracket_Returns_ThirdTaxBracketCalculator()
        {
            var annualIncome = 50000;

            var result = sut.CreateTaxCalculator(annualIncome);

            Assert.That(result, Is.TypeOf<ThirdTaxBracketCalculatorStrategy>());
        }

        [Test]
        public void When_AnnualIncomeIsLessThanFourthTaxBracketUpperLimitButGreaterThanThirdTaxBracket_Returns_FourthTaxBracketCalculator()
        {
            var annualIncome = 100000;

            var result = sut.CreateTaxCalculator(annualIncome);

            Assert.That(result, Is.TypeOf<FourthTaxBracketCalculatorStrategy>());
        }

        [Test]
        public void When_AnnualIncomeIsGreaterThanFourthTaxBracketUpperLimit_Returns_FifthTaxBracketCalculator()
        {
            var annualIncome = 200000;

            var result = sut.CreateTaxCalculator(annualIncome);

            Assert.That(result, Is.TypeOf<FifthTaxBracketCalculatorStrategy>());
        }
    }
}
