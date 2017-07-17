using MYOB_Project.ServiceLayer.Calculator.TaxCalculator;
using MYOB_Project.ServiceLayer.Interface;
using NUnit.Framework;

namespace MYOB_Project.UnitTests.TaxCalculatorTests
{
    [TestFixture]
    public class FirstTaxBracketCalculatorStrategyTests
    {
        [Test]
        public void When_FirstTaxBracketCalculatorPassedWithAnyValue_Expect_ReturnsZero()
        {
            ITaxCalculatorStrategy sut = new FirstTaxBracketCalculatorStrategy();
            var annualIncome = 15000;

            var result = sut.CalculateTax(annualIncome);

            Assert.That(result, Is.EqualTo(0));
        }
    }
}
