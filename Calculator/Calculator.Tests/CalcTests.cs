using Microsoft.QualityTools.Testing.Fakes;

namespace Calculator.Tests
{
    public class CalcTests
    {
        [Fact]
        public void Sum_1_and_2_result_3()
        {
            //Arrange
            var calc = new Calc();

            //Act
            var result = calc.Sum(1, 2);

            //Assert
            Assert.Equal(3, result);
        }

        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(-1, -2, -3)]
        [InlineData(0, 0, 0)]
        [InlineData(-2, 5, 3)]
        [InlineData(2, -5, -3)]
        public void Sum_with_results(int a, int b, int exp)
        {
            //Arrange
            var calc = new Calc();

            //Act
            var result = calc.Sum(a, b);

            //Assert
            Assert.Equal(exp, result);
        }

        [Theory]
        [InlineData(int.MaxValue, 1)]
        [InlineData(int.MaxValue - 1, 2)]
        [InlineData(int.MinValue, -1)]
        public void Sum_throws_OverflowEx(int a, int b)
        {
            var calc = new Calc();

            Assert.Throws<OverflowException>(() => calc.Sum(a, b));
        }

        [Fact]
        public void IsWeekend_Tests()
        {
            var calc = new Calc();
            using (ShimsContext.Create())
            {
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2024, 09, 23);
                Assert.False(calc.IsWeekend());
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2024, 09, 24);
                Assert.False(calc.IsWeekend());
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2024, 09, 25);
                Assert.False(calc.IsWeekend());
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2024, 09, 26);
                Assert.False(calc.IsWeekend());
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2024, 09, 27);
                Assert.False(calc.IsWeekend());

                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2024, 09, 28);
                Assert.True(calc.IsWeekend());
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2024, 09, 29);
                Assert.True(calc.IsWeekend());
            }
        }

    }
}
