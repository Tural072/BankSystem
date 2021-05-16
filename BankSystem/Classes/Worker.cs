using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    class Worker : Base
    {
        public Operation[] Operations { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Worker(Guid guid, string name, string surname, int age, string position, double salary, DateTime starttime, DateTime endtime)
                : base(guid, name, surname, age, position, salary)
        {
            StartTime = starttime;
            EndTime = endtime;
        }
        public override string ToString()
        {
            return $"Start time : {StartTime} End time : {EndTime}";
        }
        public void AddOperation(Operation operation)
        {
            Operation[] newOperation = new Operation[Operations.Length+1];
            if (Operations!=null)
            {
                Operations.CopyTo(newOperation,0);
            }
            newOperation[Operations.Length - 1] = operation;
            Operations = newOperation;
        }
    }
}
