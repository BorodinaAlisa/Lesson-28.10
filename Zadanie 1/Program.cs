using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> team = new List<string>() { "Вова", "Гриша", "Миша", "Даша", "Саша", "Арина", "Миша2", "Петя", "Степа", "Илья" };
            Project project = new Project("Проект", DateTime.Now.AddDays(7), "Initiator", "ТимЛид", team);
            project.addTask(new Task("Задача 1", DateTime.Now.AddDays(3), "Initiator"));
            project.addTask(new Task("Задача 2", DateTime.Now.AddDays(5), "Initiator"));
            project.assignTasks();
            project.transferToExecution();
            Task task1 = project.tasks[0];
            task1.startWork();
            Task task2 = project.tasks[1];
            task2.delegateTask("Новый исполнитель.");
            Report report = new Report("Текст отчета", DateTime.Now, "Исполнитель");
            task1.addReport(report);
            task1.reviewReport(true);
            if (project.isCompleted())
            {
                project.closeProject();
                Console.WriteLine("Проект завершен.");
            }
            else
            {
                Console.WriteLine("Проект не завершен.");
            }
            Console.ReadKey();
        }      
    }
}
