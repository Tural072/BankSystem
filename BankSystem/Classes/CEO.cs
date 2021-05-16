using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BankSystem
{
    class CEO : Base, IOrganize
    {
        public CEO(Guid guid, string name, string surname, int age, string position, double salary)
            : base(guid, name, surname, age, position, salary)
        {

        }
        public void Control()
        {
            Console.WriteLine("I am control all");
        }
        public void MakeMeeting(Worker[] workers)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Meeting is started");
            Console.ResetColor();
            Console.Write("ParticPant : ");
            Helper.PrintWorkers(workers);
            for (int i = 10; i > 0; i--)
            {
                Console.WriteLine($"Meeting End : {i}");
                Thread.Sleep(1000);
                Console.Clear();
            }
            Console.WriteLine("Meeting is Ended");
        }
        public void DecreasePercentage(double percent)
        {
            Credit.Percent -= percent;
        }
        public void Organize()
        {
            Console.WriteLine("I am organizer");
        }
    }
}
