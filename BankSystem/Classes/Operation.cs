using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    class Operation : Base
    {
        public string ProcessName { get; set; }
        public DateTime DateTime_ { get; set; }
        public Operation(Guid guid, string processname, DateTime dateTime) : base(guid)
        {
            ProcessName = processname;
            DateTime_ = dateTime;
        }
    }
}
