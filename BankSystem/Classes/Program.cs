using BankSystem.Exceptions;
using BankSystem.MoneyValue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Control.Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Message : {ex}");
            }
        }
    }
}
