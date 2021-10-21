using System;

namespace ATMTestGama
{
    internal class Transaction
    {
        public Transaction(decimal value, Guid userId)
        {
            this.Timestamp = DateTime.Now;
            this.TransactionValue = Math.Abs(value);
            this.TransactionType = value >= 0 ? "deposit" : "withdrawal";
            this.UserId = userId;
        }

        public DateTime Timestamp { get; }
        public decimal TransactionValue { get; }
        public string TransactionType { get; }
        public Guid UserId { get; }
    }
}