using System;

namespace tumakov_lab_6
{
    internal class Building
    {
        /// <summary>
        /// Статическая переменная для отслеживания уникальных идентификаторов
        /// </summary>
        private static int ID = 0;
        /// <summary>
        /// Уникальный идентификатор здания
        /// </summary>
        private int identificator;
        private int height;
        private int floor;
        private int countflat;
        private int entrance;

        /// <summary>
        /// Конструктор для инициализации здания с уникальным идентификатором
        /// </summary>
        public Building()
        {
            identificator = ++ID;
        }

        public Building GetInfo()
        {
            Console.WriteLine("Высота здания");
            while (!int.TryParse(Console.ReadLine(), out height))
            {
                Console.WriteLine("Ошибка ввода! Введите целое число ");
            }
            Console.WriteLine("Количество этажей");
            while (!int.TryParse(Console.ReadLine(), out floor))
            {
                Console.WriteLine("Ошибка ввода! Введите целое число ");
            }
            Console.WriteLine("Количество подъездов");
            while (!int.TryParse(Console.ReadLine(), out countflat))
            {
                Console.WriteLine("Ошибка ввода! Введите целое число ");
            }

            Console.WriteLine("Количество квартир");
            while (!int.TryParse(Console.ReadLine(), out entrance))
            {
                Console.WriteLine("Ошибка ввода! Введите целое число ");
            }

            return this;
        }

        public void Print()
        {
            Console.WriteLine("Информация о здании:");
            Console.WriteLine($"Id: {identificator}");
            Console.WriteLine($"Высота: {height}");
            Console.WriteLine($"Этажи: {floor}");
            Console.WriteLine($"Количество квартир: {countflat}");
            Console.WriteLine($"Количество подъездов: {entrance}");
        }

        public void SolutionHeight()
        {
            int heightfloor = (height / floor);
            Console.WriteLine($"Высота этажа: {heightfloor}");
        }

        public void SolutionCountFLat()
        {
            int CountFLat = (entrance / countflat);
            Console.WriteLine($"Количество квартир в подъезде: {CountFLat}");
        }

        public void SolutionCountFLatFloor(int cf)
        {
            int CountFLatFloor = (cf / floor);
            Console.WriteLine($"Количество квартир на этаже: {CountFLatFloor}");
        }

    }
}
