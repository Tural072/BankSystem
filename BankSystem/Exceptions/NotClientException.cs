using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Exceptions
{
    class NotClientException:ApplicationException
    {
        public NotClientException(string message):base(message)
        {

        }
    }
}
