using System;

namespace tumakov_lab_6
{
    /// <summary>
    /// Класс Счёт в банке
    /// </summary>
    internal class BankAccount3
    {
        /// <summary>
        /// Номер счета
        /// </summary>
        private string accountNumber;

        /// <summary>
        /// Баланс
        /// </summary>
        private double balance;

        /// <summary>
        /// Тип банковского счета
        /// </summary>
        private AccountType type;

        /// <summary>
        /// Статическая переменная
        /// </summary>
        private static int accountNumberCounter = 10000;

        /// <summary>
        /// Метод для генерации уникального номера счета
        /// </summary>
        /// <returns>Уникальный номер счета</returns>
        private static string GenerateAccountNumber()
        {
            accountNumberCounter++;
            return $"{accountNumberCounter}";
        }
        /// <summary>
        /// Конструктор для инициализации счета
        /// </summary>
        /// <param name="accBalance">Баланс</param>
        /// <param name="accType">Тип счета</param>
        public BankAccount3(double accBalance, AccountType accType)
        {
            accountNumber = GenerateAccountNumber();
            balance = accBalance;
            type = accType;
        }
        /// <summary>
        /// Метод для снятия со счета
        /// </summary>
        /// <param name="output"></param>
        public void CheckOut(double output)
        {
            if (balance > output)
            {
                balance -= output;
            }
            else
            {
                Console.WriteLine("Недостаточно денег для снятия.");
                return;
            }
        }
        /// <summary>
        /// Метод для пополнения счета
        /// </summary>
        /// <param name="input"></param>
        public void CheckBalance(double input)
        {
            balance += input;
        }
        /// <summary>
        /// Для вывода информации о счете
        /// </summary>
        /// <returns>Строка с информацией о счете</returns>
        public string AccountDetails()
        {
            return $"Номер счета: {accountNumber}\nБаланс: {balance} руб.\nТип счета: {type}";
        }
    }
}
