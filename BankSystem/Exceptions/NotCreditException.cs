using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Exceptions
{
    class NotCreditException : ApplicationException
    {
        public NotCreditException(string message):base(message)
        {

        }
    }
}
