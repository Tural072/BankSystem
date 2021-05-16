using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    class Manager : Base, IOrganize
    {
        public Manager(Guid guid, string name, string surname, int age, string position, double salary)
            : base(guid, name, surname, age, position, salary)
        {

        }
        public double CalculateSlaries(Worker[]workers)
        {
            double totalSalary = 0;
            if (workers!=null)
            {
                foreach (var item in workers)
                {
                    totalSalary += item.Salary;
                }
            }
            return totalSalary;
        }
        public void Organize()
        {
            Console.WriteLine("I am manager");
        }
    }
}
