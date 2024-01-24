using DDDInpractice.Logic;
using FluentAssertions;

namespace DDDInPractice.Test
{
    public class MoneyTest
    {
        [Fact]
        public void Sum_of_two_moneys_produces_correct_result()
        {
            //Arrange
            Money money1 = new Money(1, 2, 3, 4, 5, 6);
            Money money2 = new Money(1, 2, 3, 4, 5, 6);
            //Act
            Money sum = money1 + money2;
            //Assert
           
            sum.OneCentCount.Should().Be(2);
            sum.TenCentCount.Should().Be(4);
            sum.QuarterCount.Should().Be(6);
            sum.OneDollarCount.Should().Be(8);
            sum.FiveDollarCount.Should().Be(10);
            sum.TwentyDollarCount.Should().Be(12);
        }
        [Fact]
        public void Two_money_instatnces_same_if_contain_the_same_money()
        {
            Money money1 = new Money(1, 2, 3, 4, 5, 6);
            Money money2 = new Money(1, 2, 3, 4, 5, 6);

            money1.Should().Be(money2);

            money1.GetHashCode().Should().Be(money2.GetHashCode());
        }
        [Fact]
        public void Two_money_instatnces_are_not_same_if_contain_the_different_money()
        {
            Money money1 = new Money(1, 2, 3, 4, 5, 6);
            Money money2 = new Money(1, 4, 3, 4, 5, 6);

            money1.Should().NotBe(money2);

            money1.GetHashCode().Should().NotBe(money2.GetHashCode());
        }

        [Theory]
        [InlineData(-1, 0, 0, 0, 0, 0)]
        [InlineData(0, -2, 0, 0, 0, 0)]
        [InlineData(0, 0, -3, 0, 0, 0)]
        [InlineData(0, 0, 0, -4, 0, 0)]
        [InlineData(0, 0, 0, 0, -4, 0)]
        [InlineData(0, 0, 0, 0, 0, -5)]
        public void Cannot_create_money_with_negative_value(int OneCentCount, int TenCentCount, int QuarterCount, int OneDollarCount, int FiveDollarCount, int TwentyDollarCount)
        {
            Action action = () => new Money(OneCentCount, TenCentCount, QuarterCount, OneDollarCount, FiveDollarCount, TwentyDollarCount);
            action.Should().Throw<InvalidOperationException>();
        }
        [Theory]
        [InlineData(110, 5, 4, 6, 3, 2, 6)]
        public void Amount_is_calculated_correctly(int OneCentCount, int TenCentCount, int QuarterCount, int OneDollarCount, int FiveDollarCount, int TwentyDollarCount, int expectedAmount)
        {
            Money money = new Money(OneCentCount, TenCentCount, QuarterCount, OneDollarCount, FiveDollarCount, TwentyDollarCount);
            money.Amount.Should().Be(expectedAmount);
        }
        [Fact]
        public void Substraction_of_two_moneys_produces_correct_result()
        {
            Money money1 = new Money(10, 10, 10, 10, 10, 10);
            Money money2 = new Money(1, 2, 3, 4, 5, 6);
            Money result = money1 - money2;
            result.OneCentCount.Should().Be(9);
            result.TenCentCount.Should().Be(8);
            result.QuarterCount.Should().Be(7);
            result.OneDollarCount.Should().Be(6);
            result.FiveDollarCount.Should().Be(5);
            result.TwentyDollarCount.Should().Be(4);
        }
    }
}