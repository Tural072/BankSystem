using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Exceptions
{
    class PaymentException:ApplicationException
    {
        public PaymentException(string message):base(message)
        {

        }
    }
}
