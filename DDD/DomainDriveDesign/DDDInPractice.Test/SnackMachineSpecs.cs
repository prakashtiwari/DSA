﻿using DDDInpractice.Logic;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DDDInpractice.Logic.Money;

namespace DDDInPractice.Test
{
    public class SnackMachineSpecs
    {
        [Fact]
        public void Return_money_empties_money_in_transaction()
        {
            var snackMachine = new SnackMachine();
            snackMachine.InsertMoney(Dollar);
            snackMachine.ReturnMoney();
            snackMachine.MoneyInTransaction.Should().Be(0m);
        }
        [Fact]
        public void Inserted_money_goes_to_money_in_transaction()
        {
            var snackMachine = new SnackMachine();
            snackMachine.InsertMoney(Dollar);
            snackMachine.InsertMoney(Cent);

            snackMachine.MoneyInTransaction.Amount.Should().Be(1.01m);
        }
        [Fact]
        public void Cannot_insert_more_tah_one_coin_or_note_at_a_time()
        {
            var snackMachine = new SnackMachine();
            var twoCent = Cent + Cent;
            Action action=() => snackMachine.InsertMoney(twoCent); 
            action.Should().Throw<InvalidOperationException>();
        }
        [Fact]
        public void Money_in_transaction_go_to_money_inside_after_purchase()
        { 
        
           var snackMachine=new SnackMachine();
            snackMachine.InsertMoney(Dollar);
            snackMachine.InsertMoney(Dollar);
            snackMachine.BuySnack();
            snackMachine.MoneyInTransaction.Should().Be(None);
            snackMachine.MoneyInside.Should().Be(2m);
        }
    }
}
