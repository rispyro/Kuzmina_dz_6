using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp2.NewFolder1
{
    class Shop
    {
        private List<Bakery> products;
        public Shop(List<Bakery> products)
        {
            this.products = products;
        }
        /// <summary>
        /// Метод для добавления нового продукта
        /// </summary>
        /// <param name="product"></param>
        public void AddProduct(Bakery product)
        {
            products.Add(product);
            Console.WriteLine($"Продукт {product.Name} добавлен в магазин.");
        }
        /// <summary>
        /// Метод для удаления продукта по имени
        /// </summary>
        /// <param name="name"></param>
        public void RemoveProductByName(string name)
        {
            var productToRemove = products.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (productToRemove != null)
            {
                products.Remove(productToRemove);
                Console.WriteLine($"Продукт {name} удален из магазина.");
            }
            else
            {
                Console.WriteLine($"Товар с названием {name} не найден.");
            }
        }
        /// <summary>
        /// Метод для отображения всех продуктов
        /// </summary>
        public void ShowAllProducts()
        {
            if (products.Count == 0)
            {
                Console.WriteLine("Список товаров пуст.");
                return;
            }

            Console.WriteLine("Список доступных товаров:");
            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {products[i].Name} - Цена: {products[i].Price} рублей");
            }
        }
        /// <summary>
        /// Метод для поиска продукта по индексу
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Bakery FindProductByIndex(int index)
        {
            if (index >= 0 && index < products.Count)
                return products[index];
            else
                return null;
        }
        /// <summary>
        /// Метод для покупки продукта
        /// </summary>
        /// <param name="index"></param>
        /// <param name="quantity"></param>
        public void BuyProduct(int index, int quantity)
        {
            Bakery product = FindProductByIndex(index - 1); // Индексация начинается с 0
            if (product != null)
            {
                Console.WriteLine($"\nВы купили {quantity} {product.Name}(а)");
                Console.WriteLine($"Общая стоимость: {product.CalculateCost(quantity):F2} рублей\n");
            }
            else
            {
                Console.WriteLine("Товар не найден!");
            }
        }
        /// <summary>
        /// Метод для поиска товаров по типу
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public void ShowProductsByType<T>() where T : Bakery
        {
            var filteredProducts = products.OfType<T>().ToList();
            if (filteredProducts.Count == 0)
            {
                Console.WriteLine($"Товары типа {typeof(T).Name} не найдены.");
                return;
            }

            Console.WriteLine($"Товары типа {typeof(T).Name}:");
            foreach (var product in filteredProducts)
            {
                Console.WriteLine($"{product.Name} - Цена: {product.Price} рублей");
            }
        }
        /// <summary>
        /// Метод для применения скидки на все товары магазина
        /// </summary>
        /// <param name="discountPercentage"></param>
        public void ApplyDiscountToAll(double discountPercentage)
        {
            foreach (var product in products)
            {
                double discountAmount = product.Price * (discountPercentage / 100);
                product.Price -= discountAmount;
                Console.WriteLine($"Применена скидка на товар {product.Name}: новая цена {product.Price:F2} рублей.");
            }
        }
    }
}
