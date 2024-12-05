using System;

namespace tumakov_lab_6
{
    class Program
    {
        static void Main()
        {
            Task1();
            Task2();
            Task3();
            Task4();

            Console.ReadKey();
        }

        static void Task1()
        {
            Console.WriteLine("Упражнение 7.1");

            BankAccount account = new BankAccount("ABC1234", 10000.0, AccountType.Current);
            Console.WriteLine(account.AccountDetails());
        }

        static void Task2()
        {
            Console.WriteLine("\nУпражнение 7.2");

            BankAccount2 account2 = new BankAccount2(1000000.0, AccountType.Saving);
            Console.WriteLine(account2.AccountDetails());
        }

        static void Task3()
        {
            Console.WriteLine("\nУпражнение 7.3");

            BankAccount3 account3 = new BankAccount3(12345.6, AccountType.Current);
            Console.WriteLine(account3.AccountDetails());

            bool validInput = false;
            while (!validInput)
            {
                Console.WriteLine("\n1) Снять деньги со счета\n2) Положить деньги на счет");
                Console.Write("Выберите действие (напишите 1 или 2): ");
                string action = Console.ReadLine();
                if (int.TryParse(action, out int option))
                {
                    if (option == 1)
                    {
                        validInput = false;
                        while (!validInput)
                        {
                            Console.Write("Введите сумму для снятия: ");
                            string output = Console.ReadLine();
                            if (double.TryParse(output, out double value))
                            {
                                account3.CheckOut(value);
                                validInput = true; // Все правильно, выходим из цикла
                            }
                            else
                            {
                                Console.WriteLine("Некорректная сумма. Введите заново.");
                            }
                        }
                    }
                    else if (option == 2)
                    {
                        validInput = false;
                        while (!validInput)
                        {
                            Console.Write("Введите сумму для пополнения: ");
                            string output = Console.ReadLine();
                            if (double.TryParse(output, out double value))
                            {
                                account3.CheckBalance(value);
                                validInput = true;
                            }
                            else
                            {
                                Console.WriteLine("Некорректная сумма. Введите заново.");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Некорректный выбор. Попробуйте заново.");
                        validInput = false; 
                    }
                }
                else
                {
                    Console.WriteLine("Некорректный выбор. Попробуйте заново.");
                    validInput = false;
                }
            }

            Console.WriteLine(account3.AccountDetails());
        }
        static void Task4() 
        {
            Console.WriteLine("\nДомашнее задание 7.1");

            Building build = new Building();
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("\nВыберите одну из команд: \nзаполнить \nвывести \nвычислить высоту этажа \nвычислить количество квартир в подъезде \nвычислить количество квартир на этаже \nвыход \nВведите команду в формате, написанном в условии");

                string act = Console.ReadLine().ToLower();
                if (act.Equals("выход"))
                {
                    flag = false;
                }
                else if (act.Equals("заполнить"))
                {
                    build.GetInfo();
                }
                else if (act.Equals("вывести"))
                {
                    build.Print();
                }
                else if (act.Equals("вычислить высоту этажа"))
                {
                    build.SolutionHeight();
                }
                else if (act.Equals("вычислить количество квартир в подъезде"))
                {
                    build.SolutionCountFLat();
                }
                else if (act.Equals("вычислить количество квартир на этаже"))
                {
                    bool validInput = false;
                    while (!validInput)
                    {
                        Console.WriteLine("\nВведите количество квартир на этаже");
                        int cf;
                        if (int.TryParse(Console.ReadLine(), out cf) && cf >= 0)
                        {
                            build.SolutionCountFLatFloor(cf);
                            validInput = true;
                        }
                        else
                        {
                            Console.WriteLine("Вы ошиблись при вводе данных. Введите целое число\n");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Вы ошиблись при вводе данных. Попробуйте снова.\n");
                }
            }
        }
    }
    /// <summary>
    /// Перечислимый тип данных, отображающий виды банковского счета
    /// </summary>
    enum AccountType { Current, Saving }
}
