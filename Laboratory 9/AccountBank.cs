using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory_9
{
    enum AccountType
    {
        Current,
        Savings
    }
    internal class AccountBank
    {
        private static int accountCounter = 1000;// статическая переменная для генерации уникального номера счета
        private int AccountNumber;
        public double Balance;
        private AccountType AccountType;
        private Queue<BankTransaction> transactionHistory;
        public AccountBank()
        {
            GenerateAccountNumber();
            transactionHistory = new Queue<BankTransaction>();
        }
        public AccountBank(double initialBalance)
        {
            GenerateAccountNumber();
            Balance = initialBalance;
            transactionHistory = new Queue<BankTransaction>();
        }
        public AccountBank(AccountType type)
        {
            GenerateAccountNumber();
            AccountType = type;
            transactionHistory = new Queue<BankTransaction>();
        }
        public AccountBank(double initialBalance, AccountType type)
        {
            GenerateAccountNumber();
            Balance = initialBalance;
            AccountType = type;
            transactionHistory = new Queue<BankTransaction>();
        }
        private void GenerateAccountNumber()
        {
            AccountNumber = accountCounter;
            accountCounter++;
        }

        public int GetAccountNumber()
        {
            return AccountNumber;
        }

        public double GetBalance()
        {
            return Balance;
        }

        public AccountType GetAccountType()
        {
            return AccountType;
        }
        public void Deposit(double amount)
        {
            if (amount > 0)
            {
                Balance += amount;
                Console.WriteLine($"Депозит на {amount} выполнен.Новый баланс: {Balance}");
            }
            else
            {
                Console.WriteLine("Ошибка!Увеличьте сумму для депозита.");
            }
        }
        public void Withdraw(double amount)
        {
            if (amount > 0 && Balance >= amount)
            {
                Balance -= amount;
                Console.WriteLine($"Списание {amount} выполнено.Новый баланс: {Balance}");
            }
            else if (amount <= 0)
            {
                Console.WriteLine("Ошибка!Увеличьте сумму для списания.");
            }
            else
            {
                Console.WriteLine("Недостаточно средств на счете.");
            }
        }
        public void PrintAccount()
        {
            Console.WriteLine($"Номер счета: {AccountNumber}");
            Console.WriteLine($"Баланс: {Balance}");
            Console.WriteLine($"Тип счета: {AccountType}");
        }
        public void TransferMoney(AccountBank destinationAccount, double amount)
        {
            if (Balance >= amount)
            {
                Balance -= amount; // уменьшаем баланс текущего счета
                destinationAccount.Balance += amount; // увеличиваем баланс счета-получателя
            }
            else
            {
                Console.WriteLine("Недостаточно средств на счёте!");
            }
        }
        public void PrintTransactionHistory()
        {
            Console.WriteLine($"История операций для счета {AccountNumber}:");

            foreach (BankTransaction transaction in transactionHistory)
            {
                string transactionType = transaction.Amount >= 0 ? "Пополнение" : "Снятие";
                double transactionAmount = Math.Abs(transaction.Amount);
                Console.WriteLine(transaction.TransactionDateTime + " - " + transactionType + " на сумму " + transactionAmount);
            }
        }
        public void Dispose()
        {
            // Логика сохранения данных в файл
            using (StreamWriter writer = new StreamWriter("transactions.txt"))
            {
                foreach (var transaction in transactionHistory)
                {
                    writer.WriteLine($"{((BankTransaction)transaction).TransactionDateTime}: {((BankTransaction)transaction).Amount}");
                }
            }
            GC.SuppressFinalize(this);
        }       
    } 
}

