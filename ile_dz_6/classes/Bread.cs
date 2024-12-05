using System;

namespace ConsoleApp2.NewFolder1
{
    /// <summary>
    /// Класс Хлеб
    /// </summary>
    class Bread : Bakery
    {
        private int weight;

        /// <summary>
        /// Конструктор с указанием веса
        /// </summary>
        /// <param name="name"></param>
        /// <param name="price"></param>
        /// <param name="weight"></param>
        public Bread(string name, double price, int weight)
            : base(name, price, "Хлебобулочные изделия") 
        {
            this.weight = weight;
        }
        /// <summary>
        /// Свойство для получения веса
        /// </summary>
        public int Weight => weight;

        /// <summary>
        /// Переопределение метода для вывода информации о хлебе
        /// </summary>
        public override void GetInfo()
        {
            base.GetInfo(); 
            Console.WriteLine($"Вес: {Weight} грамм");
        }

        /// <summary>
        /// Переопределение метода для расчета стоимости хлеба
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public override double CalculateCost(int quantity)
        {
            return Price * weight / 1000 * quantity;
        }
        /// <summary>
        /// Метод для изменения веса хлеба
        /// </summary>
        /// <param name="newWeight"></param>
        public void ChangeWeight(int newWeight)
        {
            if (newWeight > 0)
            {
                weight = newWeight;
                Console.WriteLine($"Вес хлеба изменен на: {weight} грамм.");
            }
            else
            {
                Console.WriteLine("Ошибка: вес должен быть положительным числом.");
            }
        }
    }
}
