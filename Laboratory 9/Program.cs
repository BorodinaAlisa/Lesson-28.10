using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory_9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Упражнение 9.1.В классе банковский счет, созданном в предыдущих упражнениях, удалить методы заполнения полей. Вместо этих методов создать конструкторы. Переопределить конструктор по умолчанию, создать конструктор для заполнения поля баланс, конструктор для заполнения поля тип банковского счета, конструктор для заполнения баланса и типа банковского счета. Каждый конструктор должен вызывать метод, генерирующий номер счета.");
            AccountBank account1 = new AccountBank(AccountType.Current);
            account1.Deposit(10000);
            AccountBank account2 = new AccountBank(AccountType.Current);
            account2.Deposit(7777);
            AccountBank account3 = new AccountBank(AccountType.Savings);
            account3.Deposit(345);
            Console.WriteLine("Информация о счете 1:");
            account1.PrintAccount();
            Console.WriteLine("Информация о счете 2:");
            account2.PrintAccount();
            Console.WriteLine("Информация о счете 3:");
            account3.PrintAccount();
            Console.WriteLine("Упражнение 9.2. Создать новый класс BankTransaction, который будет хранить информацию о всех банковских операциях. При изменении баланса счета создается новый объект класса BankTransaction, который содержит текущую дату и время, добавленную или снятую со счета сумму. Поля класса должны быть только для чтения (readonly). Конструктору класса передается один параметр – сумма. В классе банковский счет добавить закрытое поле типа System.Collections.Queue, которое будет хранить объекты класса BankTransaction для данного банковского счета; изменить методы снятия со счета и добавления на счет так,чтобы в них создавался объект класса BankTransaction и каждый объект добавлялся в переменную типа System.Collections.Queue.");
            account1.Deposit(1000);
            account1.Withdraw(7277);
            account1.Deposit(1234321);
            account1.PrintTransactionHistory();
            Console.WriteLine("Баланс: " + account1.GetBalance());
            Console.WriteLine("Упражнение 9.3. В классе банковский счет создать метод Dispose, который данные о проводках из очереди запишет в файл. Не забудьте внутри метода Dispose вызвать метод GC.SuppressFinalize, который сообщает системе, что она не должна вызывать метод завершения для указанного объекта.");
            Console.WriteLine("Домашнее задание 9.1. В класс Song (из домашнего задания 8.2) добавить конструкторы.");
            Song song1 = new Song("Неон", "Pharaon и ЛСП");
            Song song2 = new Song("Перезаряжай", "Три дня дождя", song1);
            Song song3 = new Song("Добро пожаловать", "OgBuda и Mayot", song2);
            Song song4 = new Song("ХАЙЕГОХО", "Toxi$", song3);
            List<Song> list = new List<Song>() { song1, song2, song3, song4 };
            for (int i = 0; i < list.Count; i++)
            {
                list[i].FillName();
                list[i].FillAuthor();
                if (i != 0)
                {
                    list[i].previous = list[i - 1];
                }
                list[i].PrintTitle();

            }

            if (list[1].Equals(list[1].previous))
            {
                Console.WriteLine("Песни свопадают");
            }
            else
            {
                Console.WriteLine("Песни не совпадают.");
            }        
            Console.ReadKey();
        }
    }
}
