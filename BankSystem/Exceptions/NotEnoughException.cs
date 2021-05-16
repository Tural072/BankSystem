using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Exceptions
{
    class NotEnoughException:ApplicationException
    {
        public NotEnoughException(string message):base(message)
        {

        }
    }
}
