using BankSystem.Exceptions;
using BankSystem.MoneyValue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    class Control
    {
        static public void Run()
        {
            Worker worker = new Worker(Guid.NewGuid(), "Cavid", "Mahsumov", 16, "Programmer", 2500, DateTime.Now, DateTime.Now);
            Worker worker1 = new Worker(Guid.NewGuid(), "Murad", "Sadixov", 17, "Programmer", 2500, DateTime.Now, DateTime.Now);
            Worker worker2 = new Worker(Guid.NewGuid(), "Tural", "Tahirli", 29, "Programmer", 2500, DateTime.Now, DateTime.Now);
            Worker worker3 = new Worker(Guid.NewGuid(), "Eli", "Ibadzade", 18, "Programmer", 2500, DateTime.Now, DateTime.Now);
            Worker worker4 = new Worker(Guid.NewGuid(), "Elxan", "Atayev", 15, "Programmer", 2500, DateTime.Now, DateTime.Now);
            Worker[] workers = new Worker[5] { worker, worker1, worker2, worker3, worker4 };
            CEO ceo = new CEO(Guid.NewGuid(), "Elon", "Musk", 49, "Ceo", 5000);
            Manager manager = new Manager(Guid.NewGuid(), "John", "Johnlu", 18, "Manager", 1000);
            Manager manager1 = new Manager(Guid.NewGuid(), "Mike", "Tyson", 19, "Manager", 1000);
            Manager manager2 = new Manager(Guid.NewGuid(), "Rokky", "Balboa", 20, "Manager", 1000);
            Manager[] managers = new Manager[3] { manager, manager1, manager2 };
            Bank bank = new Bank
            {
                Name = "Yelo Bank",
                Budget = 10000000,
                Ceo = ceo
            };
            bank.AddManager(manager);
            bank.AddManager(manager1);
            bank.AddManager(manager2);
            bank.AddWorker(worker);
            bank.AddWorker(worker1);
            bank.AddWorker(worker2);
            bank.AddWorker(worker3);
            bank.AddWorker(worker4);
            Helper.ShowBankInfo(bank);
            void GiveCredit()
            {
                Console.Write("Enter Client FullName : ");
                string Name = Console.ReadLine();
                Console.WriteLine();
                Console.Write("Enter Client Surname : ");
                string surnanme = Console.ReadLine();
                Console.WriteLine();
                Console.Write("Enter The Client Age : ");
                int age = int.Parse(Console.ReadLine());
                Console.WriteLine();
                Console.Write("Enter The Salary : ");
                int salary = int.Parse(Console.ReadLine());
                Console.WriteLine();
                Console.WriteLine("Enter The CLient LiveAdress");
                string liveadress = Console.ReadLine();
                Console.Write("Enter The Client WorkAdress : ");
                string workadress = Console.ReadLine();
                Console.WriteLine();
                HelperClient.client = new Client(Guid.NewGuid(), Name, surnanme, age, salary, liveadress, workadress);
                bank.AddClient(HelperClient.client);
                Console.WriteLine("How Many want Credit ? ");
                int amount = int.Parse(Console.ReadLine());
                Console.WriteLine("How Many Month ? ");
                int month = int.Parse(Console.ReadLine());
                Credit credit = new Credit(Guid.NewGuid(), HelperClient.client, amount, 12, month, 0);
                bank.AddCredit(credit);
                bank.GiveCredit(credit);
                Console.WriteLine("Credit was Given");
                System.Threading.Thread.Sleep(1000);
                Console.Clear();
            }
            int chooseW = 0;
            int chooseM = 0;
            int chs = 0;
            void Back()
            {
                Console.WriteLine("1)Back");
                int a = int.Parse(Console.ReadLine());
                if (a == 1)
                {
                    Menu();
                }
                else
                {
                    throw new WrongSelectionException("Wrong selection");

                }
            }
            void excahngeMoney()
            {
                Console.WriteLine($"++++++++Valyuta++++++++");
                Console.WriteLine($"1)Dollar : {MoneyValues.USD}");
                Console.WriteLine($"2)Euro : {MoneyValues.Euro}");
                Console.WriteLine($"3)Tl : {MoneyValues.TL}");
                int excselection = int.Parse(Console.ReadLine());
                if (excselection == 1)
                {
                    Console.WriteLine("Money : ? ");
                    double money = double.Parse(Console.ReadLine());
                    bank.Exchange("dollar", money);
                    Console.WriteLine("Exchange Succesfly");

                }
                else if (excselection == 2)
                {
                    Console.WriteLine("Money amount ? ");
                    double money = double.Parse(Console.ReadLine());
                    bank.Exchange("euro", money);
                    Console.WriteLine("Exchange Succesfly");

                }
                else if (excselection == 3)
                {
                    Console.WriteLine("Money amount ? ");
                    double money = double.Parse(Console.ReadLine());
                    bank.Exchange("tl", money);
                    Console.WriteLine("Exchange Succesfly");
                }
                else
                {
                    throw new WrongSelectionException("Wrong Selection");
                }

            }
            void WorkerSelection()
            {
                Console.WriteLine("1)Give Information Worker");
                Console.WriteLine("2)Give Credit");
                Console.WriteLine("3)Add Operation");
                Console.WriteLine("4)Back");
                Console.Write("Your Select : ");
                chooseW = int.Parse(Console.ReadLine());
            }
            void ManagerSelection()
            {
                Helper.PrintManagers(managers);
                Console.WriteLine("Select Manager : ");
                chs = int.Parse(Console.ReadLine());
            }
            void MSelection()
            {
                Console.WriteLine($"1)Make Organizer");
                Console.WriteLine($"2)Calculate Salaries");
                Console.WriteLine("3)Back");
                chooseM = int.Parse(Console.ReadLine());
            }


            Console.WriteLine("1)Show Bank Info");
            Console.WriteLine("2)Ceo");
            Console.WriteLine("3)Manager");
            Console.WriteLine("4)Workers");
            Console.WriteLine("5)Clients");
            Console.WriteLine("6)Bank");
            Console.WriteLine("7)Exchange Money");
            Console.WriteLine("8)Exit");
            Console.WriteLine();
            Console.Write("Enter the Choose : ");
            int choose = int.Parse(Console.ReadLine());
            void Menu()
            {
                Console.Clear();
                Console.WriteLine("1)Show Bank Info");
                Console.WriteLine("2)Ceo");
                Console.WriteLine("3)Manager");
                Console.WriteLine("4)Workers");
                Console.WriteLine("5)Clients");
                Console.WriteLine("6)Bank");
                Console.WriteLine("7)Exchange Money");
                Console.WriteLine("8)Exit");
                Console.WriteLine();
                Console.Write("Enter the Choose : ");
                choose = int.Parse(Console.ReadLine());
                Console.Clear();
                SwitchSelect();

            }

            switch (choose)
            {
                case 1:
                    {
                        Helper.ShowBankInfo(bank);
                        Back();
                        break;
                    }
                case 2:
                    {
                        Helper.PrintCeo(ceo);
                        Console.WriteLine("1)Make Meeting");
                        Console.WriteLine("2)Make Organizer");
                        Console.WriteLine("3)Make Control");
                        Console.WriteLine("4)Deacrease Percentage");
                        Console.WriteLine("5)Back");
                        int choose1 = int.Parse(Console.ReadLine());
                        if (choose1 == 1)
                        {
                            ceo.MakeMeeting(workers);
                            Back();

                        }
                        else if (choose1 == 2)
                        {
                            ceo.Organize();
                            Back();
                        }
                        else if (choose1 == 3)
                        {
                            ceo.Control();
                            Back();
                        }
                        else if (choose1 == 4)
                        {
                            Console.WriteLine("Enter the deacrease Percent");
                            double deacrease = double.Parse(Console.ReadLine());
                            ceo.DecreasePercentage(deacrease);
                            Console.WriteLine(Credit.Percent);
                            Back();
                        }
                        else if (choose1 == 5)
                        {
                            Console.Clear();
                            Menu();
                        }
                        break;
                    }
                case 3:
                    {
                        ManagerSelection();
                        if (chs <= managers.Length)
                        {

                            Console.WriteLine($"Your Manager : {managers[chs - 1].Name}");
                            MSelection();
                            switch (chooseM)
                            {
                                case 1:
                                    {
                                        managers[chs - 1].Organize();
                                        Back();
                                        break;
                                    }
                                case 2:
                                    {
                                        Console.WriteLine($"Total Salaries : {managers[chs - 1].CalculateSlaries(workers)}");
                                        Back();
                                        break;
                                    }
                                case 3:
                                    {
                                        Console.Clear();
                                        Menu();
                                        break;
                                    }
                                default:
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Wrong Choose");
                                        Back();
                                        break;
                                    }


                            }

                        }
                        else
                        {

                            throw new IndexOutOfRangeException("Out of range Exception.Please Enter The 1-7 number");
                        }

                        break;
                    }
                case 4:
                    {
                        Console.WriteLine("++++++Workers++++++");
                        Helper.PrintWorkers(workers);
                        Console.Write("Your Choose : ");
                        int workchoose = int.Parse(Console.ReadLine());
                        if (workchoose <= workers.Length)
                        {
                            Console.Clear();
                            Console.WriteLine($"Your Worker : {workers[workchoose - 1].Name}");
                            WorkerSelection();
                            if (chooseW == 1)
                            {
                                Console.Clear();
                                workers[workchoose - 1].Show();
                                Back();


                            }
                            else if (chooseW == 2)
                            {

                                GiveCredit();
                                Back();

                                //MainMenu();

                            }
                            else if (chooseW == 3)
                            {
                                Console.WriteLine("What Is Prosses Name : ?");
                                string prname = Console.ReadLine();
                                workers[workchoose - 1].AddOperation(new Operation(Guid.NewGuid(), prname, DateTime.Now));
                                Back();
                            }
                            else if (chooseW == 4)
                            {
                                Console.Clear();
                                Menu();
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Workers Is Not Found");
                            Back();

                        }

                        break;
                    }
                case 5:
                    {
                        Console.Clear();
                        if (bank.Clients != null)
                        {

                            Helper.ShowBankClient(bank.Clients);
                            Back();
                        }
                        else
                        {
                            Console.WriteLine("Client Not Found");
                            Back();

                        }
                        break;
                    }
                case 6:
                    {
                        Console.WriteLine("1)Show Client Credit");
                        Console.WriteLine("2)Pay Credit");
                        Console.WriteLine("3)Show All Credit");
                        int bankchoose = int.Parse(Console.ReadLine());
                        if (bankchoose == 1)
                        {
                            Console.Write("Enter The Client Name : ");
                            string nam = Console.ReadLine();
                            bank.ShowClientCredit(nam);
                            Back();
                        }
                        else if (bankchoose == 2)
                        {
                            Console.Write("Enter The Name : ");
                            string name = Console.ReadLine();
                            Console.WriteLine();
                            Console.Write("Enter The Money : ");
                            double money = double.Parse(Console.ReadLine());
                            bank.PayCredit(name, money);
                            Back();
                        }
                        else if (bankchoose == 3)
                        {
                            bank.ShowAllCredit();
                            Back();
                        }
                        break;
                    }
                case 7:
                    {
                        excahngeMoney();
                        Back();
                        break;
                    }
                default:
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        throw new WrongSelectionException("Wrong Selection...Please Enter 1-7 number");
                        break;
                    }


            }
            void SwitchSelect()
            {
                Console.Clear();
                switch (choose)
                {
                    case 1:
                        {
                            Console.Clear();
                            Helper.ShowBankInfo(bank);
                            Back();
                            break;
                        }
                    case 2:
                        {
                            Console.Clear();
                            Helper.PrintCeo(ceo);
                            Console.WriteLine("1)Make Meeting");
                            Console.WriteLine("2)Make Organizer");
                            Console.WriteLine("3)Make Control");
                            Console.WriteLine("4)Deacrease Percentage");
                            Console.WriteLine("5)Back");
                            int choose1 = int.Parse(Console.ReadLine());
                            if (choose1 == 1)
                            {
                                ceo.MakeMeeting(workers);
                                Console.WriteLine("1)Back");
                                int a = int.Parse(Console.ReadLine());
                                Back();
                            }
                            else if (choose1 == 2)
                            {
                                Console.Clear();
                                ceo.Organize();
                                Back();
                            }
                            else if (choose1 == 3)
                            {
                                Console.Clear();
                                ceo.Control();
                                Back();
                            }
                            else if (choose1 == 4)
                            {
                                Console.Clear();
                                Console.WriteLine("Enter the deacrease Percent");
                                double deacrease = double.Parse(Console.ReadLine());
                                ceo.DecreasePercentage(deacrease);
                                Console.WriteLine(Credit.Percent);
                                Back();
                            }
                            else if (choose1 == 5)
                            {
                                Console.Clear();
                                Menu();
                            }
                            break;
                        }
                    case 3:
                        {
                            Console.Clear();
                            ManagerSelection();
                            if (chs <= managers.Length)
                            {

                                Console.WriteLine($"Your Manager : {managers[chs - 1].Name}");
                                MSelection();
                                switch (chooseM)
                                {
                                    case 1:
                                        {
                                            managers[chs - 1].Organize();
                                            Back();
                                            break;
                                        }
                                    case 2:
                                        {
                                            Console.WriteLine(managers[chs - 1].CalculateSlaries(workers));
                                            Back();
                                            break;
                                        }
                                    case 3:
                                        {
                                            Console.Clear();
                                            Menu();
                                            break;
                                        }
                                    default:
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("Wrong Choose");
                                            Back();
                                            break;
                                        }


                                }

                            }
                            else
                            {
                                throw new EmployeeNotFound("Manager Is Not Found");
                            }

                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("++++++Workers++++++");
                            Helper.PrintWorkers(workers);
                            Console.Write("Your Choose : ");
                            int workchoose = int.Parse(Console.ReadLine());
                            if (workchoose <= workers.Length)
                            {
                                Console.WriteLine($"Your Worker : {workers[workchoose - 1].Name}");
                                WorkerSelection();
                                if (chooseW == 1)
                                {
                                    Console.Clear();
                                    workers[workchoose - 1].Show();
                                    Back();

                                }
                                else if (chooseW == 2)
                                {

                                    GiveCredit();
                                    Console.Clear();


                                    Menu();
                                }
                                else if (chooseW == 3)
                                {
                                    Console.WriteLine("What Is Prosses Name : ?");
                                    string prname = Console.ReadLine();
                                    workers[workchoose - 1].AddOperation(new Operation(Guid.NewGuid(), prname, DateTime.Now));
                                    Back();
                                }
                                else if (chooseW == 4)
                                {
                                    Console.Clear();
                                    Menu();
                                }
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                throw new EmployeeNotFound("Worker Is Not Found");
                            }

                            break;
                        }
                    case 5:
                        {
                            if (bank.Clients != null)
                            {
                                Console.Clear();
                                Helper.ShowBankClient(bank.Clients);
                                Back();
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Client not Found");
                                Console.ResetColor();
                                Back();
                            }
                            break;
                        }
                    case 6:
                        {
                            Console.Clear();
                            Console.WriteLine("1)Show Client Credit");
                            Console.WriteLine("2)Pay Credit");
                            Console.WriteLine("3)Show All Credit");
                            int bankchoose = int.Parse(Console.ReadLine());
                            if (bankchoose == 1)
                            {
                                Console.Clear();
                                Console.Write("Enter The Client Name : ");
                                string nam = Console.ReadLine();



                                bank.ShowClientCredit(nam);

                                Back();

                            }
                            else if (bankchoose == 2)
                            {
                                Console.Clear();
                                Console.Write("Enter The Name : ");
                                string name = Console.ReadLine();
                                Console.WriteLine();
                                Console.Write("Enter The Money : ");
                                double money = double.Parse(Console.ReadLine());
                                bank.PayCredit(name, money);
                                Console.WriteLine("1)Back");
                                int a = int.Parse(Console.ReadLine());
                                if (a == 1)
                                {
                                    Console.Clear();
                                    Menu();
                                }
                                else
                                {
                                    throw new IndexOutOfRangeException("Wrong Number");
                                }


                            }
                            else if (bankchoose == 3)
                            {
                                Console.Clear();
                                bank.ShowAllCredit();
                                Back();

                            }
                            break;
                        }
                    case 7:
                        {
                            excahngeMoney();
                            Back();

                            break;
                        }
                    case 8:
                        {
                            Console.WriteLine("Waiting Again ");
                            Environment.Exit(7);
                            break;
                        }
                    default:
                        {
                            throw new IndexOutOfRangeException("Out of Range Exception...Please Enter The 1-7 number");
                            break;
                        }
                }
            }
        }
    }
}
