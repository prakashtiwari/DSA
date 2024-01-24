﻿namespace DDDInpractice.Logic
{
    //Value object should be immutable.
    public class Money
    {
        public static readonly Money None = new Money(0, 0, 0, 0, 0, 0);
        public static readonly Money Cent = new Money(1, 0, 0, 0, 0, 0);
        public static readonly Money TenCent = new Money(0, 1, 0, 0, 0, 0);
        public static readonly Money Quarter = new Money(0, 0, 1, 0, 0, 0);
        public static readonly Money Dollar = new Money(0, 0, 0, 1, 0, 0);
        public static readonly Money FiveDollar = new Money(0, 0, 0, 0, 1, 0);
        public static readonly Money TwentyDollar = new Money(0, 0, 0, 0, 0, 0);
        public int OneCentCount { get; }
        public int TenCentCount { get; }
        public int QuarterCount { get; }
        public int OneDollarCount { get; }
        public int FiveDollarCount { get; }
        public int TwentyDollarCount { get; }
        public decimal Amount { get { return OneCentCount * 0.01m + TenCentCount * 0.10m + QuarterCount * 0.25m + OneDollarCount + FiveDollarCount * 5 + TwentyDollarCount * 20; } }
        public Money(int oneCentCount, int tenCentCount, int quarterCount, int oneDollarCount, int fiveDollarCount, int twentyDollarCount)
        {
            if (oneCentCount < 0)
                throw new InvalidOperationException();
            if (tenCentCount < 0)
                throw new InvalidOperationException();
            if (quarterCount < 0)
                throw new InvalidOperationException();
            if (oneDollarCount < 0)
                throw new InvalidOperationException();
            if (fiveDollarCount < 0)
                throw new InvalidOperationException();
            if (twentyDollarCount < 0)
                throw new InvalidOperationException();
            this.OneCentCount = oneCentCount;
            this.TenCentCount = tenCentCount;
            this.QuarterCount = quarterCount;
            this.OneDollarCount = oneDollarCount;
            this.FiveDollarCount = fiveDollarCount;
            this.TwentyDollarCount = twentyDollarCount;
        }
        public static Money operator +(Money money1, Money money2)
        {
            Money sum = new Money(
                money1.OneCentCount + money2.OneCentCount,
                money1.TenCentCount + +money2.TenCentCount,
                money1.QuarterCount + money2.QuarterCount,
               money1.OneDollarCount + money2.OneDollarCount,
                money1.FiveDollarCount + money2.FiveDollarCount,
               money1.TwentyDollarCount + money2.TwentyDollarCount
            );
            return sum;
        }
        /// <summary>
        /// Subtract
        /// </summary>
        /// <param name="money1"></param>
        /// <param name="money2"></param>
        /// <returns></returns>
        public static Money operator -(Money money1, Money money2)
        {
            return new Money(money1.OneCentCount - money2.OneCentCount,
                money1.TenCentCount - money2.TenCentCount,
                money1.QuarterCount - money2.QuarterCount,
                money1.OneDollarCount - money2.OneDollarCount,
                money1.FiveDollarCount - money2.FiveDollarCount,
                money1.TwentyDollarCount - money2.TwentyDollarCount);
        }
    }
}