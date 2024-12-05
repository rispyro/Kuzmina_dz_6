using System;

namespace ConsoleApp2.NewFolder1
{
    abstract class Bakery
    {
        /// <summary>
        /// Название товара
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Цена товара
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Категория товара
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Конструктор для инициализации товара
        /// </summary>
        /// <param name="name">Название товара</param>
        /// <param name="price">Цена товара</param>
        /// <param name="category">Категория товара</param>
        protected Bakery(string name, double price, string category)
        {
            Name = name;
            Price = price;
            Category = category;
        }

        /// <summary>
        /// Метод для вывода информации о товаре
        /// </summary>
        public virtual void GetInfo()
        {
            Console.WriteLine($"Название: {Name}, Цена: {Price}, Категория: {Category}");
        }
        /// <summary>
        /// Метод для расчета стоимости товара
        /// </summary>
        /// <param name="quantity">Количество</param>
        /// <returns>Стоимость для заданного количества товара</returns>
        public abstract double CalculateCost(int quantity);
        /// <summary>
        /// Метод для применения скидки на товар
        /// </summary>
        /// <param name="discountPercent">Процент скидки</param>
        public void ApplyDiscount(double discountPercent)
        {
            if (discountPercent < 0 || discountPercent > 100)
            {
                Console.WriteLine("Ошибка: скидка должна быть в пределах от 0 до 100.");
                return;
            }
            Price -= Price * discountPercent / 100;
            Console.WriteLine($"Скидка {discountPercent}% применена. Новая цена: {Price:F2}.");
        }
    }
}
