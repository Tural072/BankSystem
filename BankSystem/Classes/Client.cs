using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    class Client : Base
    {
        public string LiveAdress { get; set; }
        public string WorkAdress { get; set; }
        public Client(Guid guid, string name, string surname, int age, double salary, string liveadress, string workadress)
            : base(guid, name, surname, age, salary)
        {
            LiveAdress = liveadress;
            WorkAdress = workadress;
        }
    }
}
