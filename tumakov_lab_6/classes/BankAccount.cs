using System;

namespace tumakov_lab_6
{ 
    /// <summary>
    /// Класс Счёт в банке
    /// </summary>
    internal class BankAccount
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
        /// Конструктор для инициализации счета
        /// </summary>
        /// <param name="accountNumber">Номер счета</param>
        /// <param name="balance">Баланс</param>
        /// <param name="type">Тип счета</param>
        public BankAccount(string AccountNumber, double Balance, AccountType Type)
        {
            accountNumber = AccountNumber;
            balance = Balance;
            type = Type;
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