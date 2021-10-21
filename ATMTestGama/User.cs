using System;

namespace ATMTestGama
{
    internal class User
    {
        public User(string name, string password)
        {
            this.Name = name;
            this.Password = password;
            this.Id = Guid.NewGuid();
        }

        public User(string name, string password, decimal accountBalance) : this(name, password)
        {
            this.AccountBalance = accountBalance;
        }

        public void DepositValue(decimal value)
        {
            AccountBalance += value;
        }

        public void WithdrawValue(decimal value)
        {
            AccountBalance -= value;
        }

        public string Name { get; }
        public string Password { get; }
        public Guid Id { get; }
        public decimal AccountBalance { get; private set; }
    }
}