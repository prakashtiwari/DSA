using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DDDInpractice.Logic.Money;
namespace DDDInpractice.Logic
{
    public sealed class SnackMachine : Entity
    {

        public Money MoneyInside { get; private set; } = None;
        public Money MoneyInTransaction { get; private set; } = None;

        public SnackMachine()
        {
            MoneyInside = None;
            MoneyInTransaction = None;
        }
        public void InsertMoney(Money money)
        {
            Money[] coinsAndNote = { Cent, TenCent, Quarter, Dollar, FiveDollar, TwentyDollar };
            if (!coinsAndNote.Contains(money))
            { 
                throw new InvalidOperationException();
            }
            MoneyInTransaction += money;
        }
        public void ReturnMoney()
        {
            MoneyInTransaction = None;
        }
        public void BuySnack()
        {
            MoneyInside += MoneyInTransaction;
            MoneyInTransaction = None;
        }
    }
}
