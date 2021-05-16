using BankSystem.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BankSystem.MoneyValue;

namespace BankSystem
{
    class Bank
    {
        //exchange servise helper class yaratmaq valyutalari hesablamaq lazimdir
        public string Name { get; set; }
        public double Budget { get; set; }
        public double Profit { get; set; }
        public CEO Ceo { get; set; }
        public Worker[] Workers { get; set; }
        public Manager[] Managers { get; set; }
        public Client[] Clients { get; set; }
        public Credit[] Credits { get; set; }
        public int WorkerCount { get; set; }
        public int ManagerCount { get; set; }
        public int ClientCount { get; set; }
        public override string ToString()
        {
            return $"Name : {Name} Budeget : {Budget} Profit : {Profit} Worker count : {WorkerCount} Client count : {ClientCount}";
        }
        public void Exchange(string type, double money)
        {
            if (Budget >= money)
            {
                double sum = 0;
                if (type=="dollar")
                {
                    Budget += (MoneyValues.USD) / 100 * 5;
                    sum = MoneyValues.USD * money;
                    Console.WriteLine($"AZN : { sum}");
                }
                else if (type=="euro")
                {
                    Budget += (MoneyValues.Euro) / 100 * 5;
                    sum = MoneyValues.Euro * money;
                    Console.WriteLine($"AZN : { sum}");
                }
                else if (type == "tl")
                {
                    Budget += (MoneyValues.TL) / 100 * 5;
                    sum = MoneyValues.TL * money;
                    Console.WriteLine($"AZN : { sum}");
                }
                else
                {
                    throw new ExchanhgeException("Wrong selection");
                }
            }
            else
            {
                throw new NotEnoughException("Bank does not had this funds");
            }
        }
        public void ShowClientCredit(string fullname)
        {
            foreach (var item in Credits)
            {
                if (item.Client_.Name == fullname)
                {
                    item.Show();
                }
            }
        }
        public void AddWorker(Worker worker)
        {
            Worker[] newWorkers = new Worker[++WorkerCount];
            if (Workers != null)
            {
                this.Workers.CopyTo(newWorkers, 0);
            }
            newWorkers[newWorkers.Length - 1] = worker;
            this.Workers = newWorkers;
        }
        public void AddCredit(Credit credit)
        {
            Credit[] newCredit = new Credit[Credits.Length+1];
            if (Credits != null)
            {
                Credits.CopyTo(newCredit, 0);
            }
            newCredit[newCredit.Length - 1] = credit;
            Credits = newCredit;
        }
        public void AddManager(Manager manager)
        {
            Manager[] newManager = new Manager[++ManagerCount];
            if (Managers != null)
            {
                this.Managers.CopyTo(newManager, 0);
            }
            newManager[newManager.Length - 1] = manager;
            this.Managers = newManager;
        }
        public void AddClient(Client client)
        {
            Client[] newclients = new Client[++ClientCount];
            if (this.Clients != null)
            {
                this.Clients.CopyTo(newclients, 0);
            }
            newclients[newclients.Length - 1] = client;
            this.Clients = newclients;
        }
        public void GiveCredit(Credit credit)
        {
            try
            {
                if (Budget >= credit.Amount)
                {
                    Budget -= credit.Amount;
                    Profit += credit.Amount / 100 * 12;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Thread.Sleep(1000);
                    Console.ResetColor();
                    throw new NotCreditException(" Credit exception ");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Message : {ex}");
            }
        }
        public void PayCredit(string name, double money)
        {
            foreach (var item in Credits)
            {
                if (name == item.Client_.Name)
                {
                    item.Payment += money;
                    item.Amount -= money;
                    break;
                }
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Thread.Sleep(2000);
            throw new NotClientException("Client is not found");
        }
        public void ShowAllCredit()
        {
            foreach (var item in Credits)
            {
                item.Show();
            }
        }
    }
}
