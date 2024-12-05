using System;

namespace ConsoleApp2.NewFolder1
{
    /// <summary>
    /// Класс Сладкое
    /// </summary>
    class Pastry : Bakery
    {
        private bool isSweet; 
        private string type;

        /// <summary>
        /// Конструктор с указанием славкий/несладкий
        /// </summary>
        /// <param name="name"></param>
        /// <param name="price"></param>
        /// <param name="isSweet"></param>
        /// <param name="type"></param>
        public Pastry(string name, double price, bool isSweet, string type)
     : base(name, price, type) 
        {
            this.isSweet = isSweet; 
        }
        /// <summary>
        /// Свойства для доступа
        /// </summary>
        public bool IsSweet => isSweet;
        public string Type => type;
        /// <summary>
        /// Переопределенный метод для получения информации о изделии
        /// </summary>
        public override void GetInfo()
        {
            base.GetInfo();
            Console.WriteLine($"Тип: {Type}");
        }
        /// <summary>
        /// Метод для расчета стоимости в зависимости от сладости
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public override double CalculateCost(int quantity)
        {
            if (isSweet)
                return (Price + 10) * quantity; 
            else
                return Price * quantity;
        }
    }
}
