using System;

namespace BankAccountNS
{
   
    public class BankAccount
    {
        private string customerName;

        private double balance;

        private bool frozen = false;


        private BankAccount()
        {
        }

        public BankAccount(string cn, double b)
        {
            customerName = cn;
            balance = b;
        }

        public string CustomerName
        {
            get { return customerName; }
        }

        public double Balance
        {
            get { return balance; }
        }

        public void Debit(double amount)
        {
            if (frozen)
            {
                throw new Exception("Tili on jäädytetty");
            }

            if (amount > balance)
            {
                throw new ArgumentOutOfRangeException("amount");
            }

            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount");
            }

            balance -= amount;
        }

        public void Credit(double amount)
        {
            if (frozen)
            {
                throw new Exception("Tili on jäädytetty");
            }

            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount");
            }

           balance += amount;
        }

        public void FreezeAccount()
        {
           frozen = true;
        }

        public void UnfreezeAccount()
        {
            frozen = false;
        }

        public static void Main()
        {
            BankAccount ba = new BankAccount("Matti meikäläinen", 11.99);

            ba.Credit(5.77);
            ba.Debit(11.22);
            Console.WriteLine("Pankkitilin raha määrä ${0}", ba.Balance);
        }

    }
}
