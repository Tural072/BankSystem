using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    class Credit : Base
    {
        //Credit yarananda Clientle birlikde yaranir
        public Client Client_ { get; set; }
        public double Amount { get; set; }
        static public double Percent { get; set; }
        public int Months { get; set; }
        public double Payment { get; set; }
        public double PaymentPerMonth { get; set; }
        public Credit(Guid guid, Client client, double amount, double percent, int months, double payment) : base(guid)
        {
            Client_ = client;
            Amount = amount;
            Percent = percent;
            Months = months;
            Payment = payment;
        }
        public void PayCredit(double money)
        {
            if (Payment != 0 && money > 0)
            {
                Payment -= money;
            }
        }
        public void CalculatePercent()
        {
            double payment =(Amount*Percent)+Amount;
            double paymentPerMonth = payment / Months;
            Payment = payment;
            PaymentPerMonth = paymentPerMonth;
            Console.WriteLine($"Your payment : {payment}");
            Console.WriteLine($"Your payment per month : {paymentPerMonth}");
        }
        public new void Show() {
            Client_.Show();
            Console.WriteLine($"Amount : {Amount}");
            Console.WriteLine($"Payment : {Payment}");
            Console.WriteLine($"Payment per month : {PaymentPerMonth}");
            Console.WriteLine($"Month : {Months}");
            Console.WriteLine($"Percent : {Percent}");
        }
    }
}
