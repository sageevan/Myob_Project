using MYOB_Project.ServiceLayer.Calculator;
using MYOB_Project.ServiceLayer.Interface;
using NUnit.Framework;

namespace MYOB_Project.UnitTests
{
    [TestFixture]
    public class PayPeriodCalculatorTests
    {
        public IPayPeriodCalculator sut;

        [SetUp]
        public void Init()
        {
            sut = new PayPeriodCalculator();
        }

        [Test]
        public void When_JanuaryMonthIsPassed_Expect_Returns1stAnd31stJan()
        {
            var year = 2017;
            var month = 1;

            var result = sut.GetPayPeriod(year, month);

            Assert.That(result, Is.EqualTo("01 January - 31 January"));
        }

        [Test]
        public void When_SeptemberMonthIsPassed_Expect_Returns1stAnd30thSep()
        {
            var year = 2017;
            var month = 9;

            var result = sut.GetPayPeriod(year, month);

            Assert.That(result, Is.EqualTo("01 September - 30 September"));
        }

        [Test]
        public void When_DecemberMonthIsPassed_Expect_Returns1stAnd31stDec()
        {
            var year = 2017;
            var month = 12;

            var result = sut.GetPayPeriod(year, month);

            Assert.That(result, Is.EqualTo("01 December - 31 December"));
        }

        [Test]
        public void When_FebruaryMonthIsPassedInLeapYear_Expect_Returns1stAnd29thFeb()
        {
            var year = 2016;
            var month = 2;

            var result = sut.GetPayPeriod(year, month);

            Assert.That(result, Is.EqualTo("01 February - 29 February"));
        }

        [Test]
        public void When_FebruaryMonthIsPassedInNotLeapYear_Expect_Returns1stAnd28thFeb()
        {
            var year = 2017;
            var month = 2;

            var result = sut.GetPayPeriod(year, month);

            Assert.That(result, Is.EqualTo("01 February - 28 February"));
        }
    }
}
