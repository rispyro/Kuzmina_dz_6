using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApp2.NewFolder1;

class Program
{
    static void Main()
    {
        List<Bakery> products = new List<Bakery>
        {
            new Bread("Ржаной хлеб", 50, 700),
            new Pastry("Пирожное", 120, true, "Сладкое"),
            new Bread("Белый хлеб", 55, 500)
        };
        Shop shop = new Shop(products);
        bool continueShopping = true;
        while (continueShopping)
        {
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1. Добавить новый товар");
            Console.WriteLine("2. Совершить покупку");
            Console.WriteLine("3. Удалить товар");
            Console.WriteLine("4. Просмотр всех товаров");
            Console.WriteLine("5. Просмотр товаров по категории");
            Console.WriteLine("6. Применить скидку ко всем товарам");
            Console.Write("Введите номер действия: ");

            int actionChoice;
            bool isValidActionChoice = int.TryParse(Console.ReadLine(), out actionChoice);

            if (!isValidActionChoice)
            {
                Console.WriteLine("Некорректный ввод! Пожалуйста, введите число.");
                continue;
            }

            switch (actionChoice)
            {
                case 1:
                    /// Добавление нового товара
                    Console.Write("Введите название товара: ");
                    string name = Console.ReadLine();

                    Console.Write("Введите цену товара: ");
                    double price;
                    bool isValidPrice = double.TryParse(Console.ReadLine(), out price);

                    if (!isValidPrice)
                    {
                        Console.WriteLine("Некорректная цена! Попробуйте снова.");
                        continue;
                    }

                    Console.WriteLine("Выберите тип товара:");
                    Console.WriteLine("1. Хлеб");
                    Console.WriteLine("2. Кондитерское изделие");

                    int productType;
                    bool isValidProductType = int.TryParse(Console.ReadLine(), out productType);

                    if (!isValidProductType)
                    {
                        Console.WriteLine("Некорректный выбор типа товара! Попробуйте снова.");
                        continue;
                    }

                    if (productType == 1)
                    {
                        Console.Write("Введите вес хлеба в граммах: ");
                        int weight;
                        bool isValidWeight = int.TryParse(Console.ReadLine(), out weight);

                        if (!isValidWeight)
                        {
                            Console.WriteLine("Некорректный вес! Попробуйте снова.");
                            continue;
                        }

                        shop.AddProduct(new Bread(name, price, weight));
                    }
                    else if (productType == 2)
                    {
                        Console.Write("Сладкое (true/false): ");
                        bool isSweet;
                        bool isValidSweet = bool.TryParse(Console.ReadLine(), out isSweet);

                        if (!isValidSweet)
                        {
                            Console.WriteLine("Некорректный ввод! Попробуйте снова.");
                            continue;
                        }

                        shop.AddProduct(new Pastry(name, price, isSweet, "Сладкое"));
                    }

                    Console.WriteLine("Товар добавлен!\n");
                    break;

                case 2:
                    /// Совершение покупки
                    shop.ShowAllProducts();

                    Console.Write("Выберите товар (номер): ");
                    int choice;
                    bool isValidChoice = int.TryParse(Console.ReadLine(), out choice);

                    if (!isValidChoice)
                    {
                        Console.WriteLine("Некорректный выбор товара! Попробуйте снова.");
                        continue;
                    }

                    Console.Write("Укажите количество: ");
                    int quantity;
                    bool isValidQuantity = int.TryParse(Console.ReadLine(), out quantity);

                    if (!isValidQuantity)
                    {
                        Console.WriteLine("Некорректное количество! Попробуйте снова.");
                        continue;
                    }

                    shop.BuyProduct(choice, quantity);
                    break;

                case 3:
                    /// Удаление товара
                    Console.WriteLine("Введите название товара для удаления: ");
                    string productName = Console.ReadLine();
                    shop.RemoveProductByName(productName);
                    break;

                case 4:
                    /// Просмотр всех товаров
                    shop.ShowAllProducts();
                    break;

                case 5:
                    /// Просмотр товаров по категории
                    Console.WriteLine("Выберите категорию:");
                    Console.WriteLine("1. Хлеб");
                    Console.WriteLine("2. Кондитерское изделие");

                    int categoryChoice;
                    bool isValidCategoryChoice = int.TryParse(Console.ReadLine(), out categoryChoice);

                    if (!isValidCategoryChoice)
                    {
                        Console.WriteLine("Некорректный выбор категории! Попробуйте снова.");
                        continue;
                    }

                    if (categoryChoice == 1)
                    {
                        shop.ShowProductsByType<Bread>();
                    }
                    else if (categoryChoice == 2)
                    {
                        shop.ShowProductsByType<Pastry>();
                    }
                    break;

                case 6:
                    /// Применение скидки ко всем товарам
                    Console.Write("Введите процент скидки: ");
                    double discountPercentage;
                    bool isValidDiscount = double.TryParse(Console.ReadLine(), out discountPercentage);

                    if (!isValidDiscount)
                    {
                        Console.WriteLine("Некорректная скидка! Попробуйте снова.");
                        continue;
                    }

                    shop.ApplyDiscountToAll(discountPercentage);
                    break;

                default:
                    Console.WriteLine("Неверный выбор. Попробуйте снова.");
                    break;
            }
            Console.Write("Продолжить действия? (Y/N): ");
            char answer = Char.ToUpper(Console.ReadKey().KeyChar);
            Console.WriteLine();
            if (answer == 'N')
                continueShopping = false;
        }
        Console.WriteLine("Спасибо за покупку! До свидания!");
    }
}
