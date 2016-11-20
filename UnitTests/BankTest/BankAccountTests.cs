using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccountNS;

namespace BankTest
{
    [TestClass]
    public class BankAccountTests
    {
        [TestMethod]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            BankAccount account = new BankAccount("Matti Meikäläinen", beginningBalance);
 
            account.Debit(debitAmount);

            double actual = account.Balance;
            Assert.AreEqual(expected, actual, "Tililtä on veloitettu väärin");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            double beginningBalance = 11.99;
            double debitAmount = -100.00;
            BankAccount account = new BankAccount("Matti Meikäläinen", beginningBalance);

            account.Debit(debitAmount);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange()
        {
            double beginningBalance = 11.99;
            double debitAmount = 200.00;
            BankAccount account = new BankAccount("Matti Meikäläinen", beginningBalance);

            account.Debit(debitAmount);  
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Debit_WhenAccountIsFrozen_ShouldThrowException()
        {
            double beginningBalance = 11.99;
            double debitAmount = 4.00;
            BankAccount account = new BankAccount("Matti Meikäläinen", beginningBalance);

            account.FreezeAccount();
            account.Debit(debitAmount);
        }

        [TestMethod]
        public void Credit_WithValidAmount_UpdatesBalance()
        {
            double beginningBalance = 12.00;
            double creditAmount = 4.55;
            double expected = 16.55;
            BankAccount account = new BankAccount("Matti Meikäläinen", beginningBalance);

            account.Credit(creditAmount);

            double actual = account.Balance;
            Assert.AreEqual(expected, actual, "Luoton siirto ei toiminut");
        }

    }
}
