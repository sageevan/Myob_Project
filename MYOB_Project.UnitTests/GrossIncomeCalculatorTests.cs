using MYOB_Project.ServiceLayer.Calculator;
using MYOB_Project.ServiceLayer.Interface;
using NUnit.Framework;

namespace MYOB_Project.UnitTests
{
    [TestFixture]
    public class GrossIncomeCalculatorTests
    {
        public IGrossIncomeCalculator sut;

        [SetUp]
        public void Init()
        {
            sut = new GrossIncomeCalculator();
        }

        [Test]
        public void When_GrossIncomeCalculatorCalledWithZero_Expect_ReturnsZero()
        {
            var annualIncome = 0;

            var result = sut.Calculate(annualIncome);

            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void When_GrossIncomeCalculatorCalledWithNumberExactlyDivisibleBy12_Expect_ReturnsWholeNumber()
        {
            var annualIncome = 72000;

            var result = sut.Calculate(annualIncome);

            Assert.That(result, Is.EqualTo(6000));
        }

        [Test]
        public void When_GrossIncomeCalculatorResultHasDecimalLessThanFiftyCents_Expect_ReturnsWholeNumberRoundedDown()
        {
            var annualIncome = 72050;

            var result = sut.Calculate(annualIncome);

            Assert.That(result, Is.EqualTo(6004));
        }

        [Test]
        public void When_GrossIncomeCalculatorResultHasDecimalMoreThanFiftyCents_Expect_ReturnsWholeNumberRoundedToNextHigherNumber()
        {
            var annualIncome = 72059;

            var result = sut.Calculate(annualIncome);

            Assert.That(result, Is.EqualTo(6005));
        }

        [Test]
        public void When_GrossIncomeCalculatorResultHasDecimalExactlyFiftyCents_Expect_ReturnsWholeNumberRoundedToNextHigherNumber()
        {
            var annualIncome = 48054;

            var result = sut.Calculate(annualIncome);

            Assert.That(result, Is.EqualTo(4005));
        }
    }
}
