using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory_9
{
    internal class BankTransaction
    {
        public readonly DateTime TransactionDateTime;
        public readonly double Amount;

        public BankTransaction(double amount)
        {
            TransactionDateTime = DateTime.Now;
            Amount = amount;
        }
    }
}
