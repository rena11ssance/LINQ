using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<PersonalComputers> personalComputers = new List<PersonalComputers>()
            {
                new PersonalComputers() { Id = 1, computerBrand = "Dell", processorType = "Intel", operatingFrequency = 3600, amountOfRandomAccessMemory = 16, hardDriveCapacity = 512, videoCardMemoryCapacity = 4, computerCost = 65000, quantityInStock = 5 },
                new PersonalComputers() { Id = 2, computerBrand = "HP", processorType = "Intel", operatingFrequency = 4200, amountOfRandomAccessMemory = 32, hardDriveCapacity = 1000, videoCardMemoryCapacity = 8, computerCost = 95000, quantityInStock = 3 },
                new PersonalComputers() { Id = 3, computerBrand = "MSI", processorType = "AMD", operatingFrequency = 3800, amountOfRandomAccessMemory = 8, hardDriveCapacity = 256, videoCardMemoryCapacity = 2, computerCost = 45000, quantityInStock = 31 },
                new PersonalComputers() { Id = 4, computerBrand = "Asus", processorType = "Intel", operatingFrequency = 5000, amountOfRandomAccessMemory = 64, hardDriveCapacity = 2000, videoCardMemoryCapacity = 12, computerCost = 150000, quantityInStock = 2 },
                new PersonalComputers() { Id = 5, computerBrand = "Dell", processorType = "AMD", operatingFrequency = 4300, amountOfRandomAccessMemory = 16, hardDriveCapacity = 1000, videoCardMemoryCapacity = 6, computerCost = 78000, quantityInStock = 30 },
                new PersonalComputers() { Id = 6, computerBrand = "Apple", processorType = "M1", operatingFrequency = 3200, amountOfRandomAccessMemory = 16, hardDriveCapacity = 512, videoCardMemoryCapacity = 16, computerCost = 120000, quantityInStock = 4 },
                new PersonalComputers() { Id = 7, computerBrand = "MSI", processorType = "Intel", operatingFrequency = 3500, amountOfRandomAccessMemory = 8, hardDriveCapacity = 500, videoCardMemoryCapacity = 4, computerCost = 55000, quantityInStock = 7 },
                new PersonalComputers() { Id = 8, computerBrand = "Asus", processorType = "Intel", operatingFrequency = 3100, amountOfRandomAccessMemory = 4, hardDriveCapacity = 128, videoCardMemoryCapacity = 2, computerCost = 35000, quantityInStock = 10 },
                new PersonalComputers() { Id = 9, computerBrand = "Sony", processorType = "AMD", operatingFrequency = 4700, amountOfRandomAccessMemory = 32, hardDriveCapacity = 2000, videoCardMemoryCapacity = 10, computerCost = 110000, quantityInStock = 3 },
                new PersonalComputers() { Id = 10, computerBrand = "Apple", processorType = "Intel", operatingFrequency = 3400, amountOfRandomAccessMemory = 12, hardDriveCapacity = 750, videoCardMemoryCapacity = 3, computerCost = 60000, quantityInStock = 5 }
            };

            #region Вывод списка всех ПК
            Console.WriteLine("================================================================================================================");
            Console.WriteLine("                     Список доступных компьютеров и их характеристики");
            Console.WriteLine("================================================================================================================\n");

            Print.PrintOutput(personalComputers);
            #endregion

            #region Отбор по процессору
            Console.WriteLine("\n===========================================");
            Console.WriteLine("             Отбор по процессору");
            Console.WriteLine("===========================================");
            Console.Write("Введите тип процессора (Intel/AMD/M1): ");

            string firstInput = Console.ReadLine();
            List<PersonalComputers> separateProcessor = personalComputers
                .Where(d => d.processorType == firstInput)
                .ToList();

            Console.WriteLine($"\nСписок ПК с процессором {firstInput}:");
            Console.WriteLine("-------------------------------------------");

            Print.PrintOutput(separateProcessor);
            #endregion

            #region Отбор по объему ОЗУ
            Console.WriteLine("\n");
            Console.WriteLine("===========================================");
            Console.WriteLine("             Отбор по объему ОЗУ");
            Console.WriteLine("===========================================");
            Console.Write("Введите минимальный объем ОЗУ (GB): ");

            int secondInput = Convert.ToInt32(Console.ReadLine());
            List<PersonalComputers> randomAccessMemorySeparate = personalComputers
                .Where(d => d.amountOfRandomAccessMemory >= secondInput)
                .ToList();

            Console.WriteLine($"\nСписок ПК с объемом ОЗУ больше {secondInput} GB:");
            Console.WriteLine("-------------------------------------------");

            Print.PrintOutput(randomAccessMemorySeparate);
            #endregion

            Console.WriteLine("\n===========================================");
            Console.Write("Нажмите на любую клавишу для сортировки ПК по стоимости: \n");
            Console.WriteLine("===========================================");
            Console.ReadKey();

            #region Сортируем по стоимости
            Console.WriteLine("\n");
            Console.WriteLine("===========================================");
            Console.WriteLine("             Сортируем по стоимости ПК");
            Console.WriteLine("===========================================");

            List<PersonalComputers> CostSort = personalComputers
                .OrderBy(d => d.computerCost)
                .ToList();

            Print.PrintOutput(CostSort);
            #endregion

            #region Группировка по типу процессора
            IEnumerable<IGrouping<string, PersonalComputers>> processorGroup = personalComputers
                .GroupBy(d => d.processorType);

            Print.PrintGroup(processorGroup);
            #endregion

            Console.WriteLine("\n===========================================");
            Console.WriteLine("Нажмите любую клавишу для вывода самого дорогого и бюджетного ПК: ");
            Console.WriteLine("===========================================");
            Console.ReadKey();

            #region Нахождение самого дорогого и бюджетного ПК
            PersonalComputers mostExpensive = personalComputers
                .OrderByDescending(d => d.computerCost)
                .FirstOrDefault();

            PersonalComputers mostBudget = personalComputers
                .OrderBy(d => d.computerCost)
                .FirstOrDefault();

            Print.SimpleOutput(mostExpensive, mostBudget);
            #endregion

            Console.WriteLine("\n===========================================");
            Console.WriteLine("Нажмите любую клавишу для вывода ПК с количеством более 30 штук.");
            Console.WriteLine("===========================================");
            Console.ReadKey();

            #region Узнаём, есть ли хотя бы один компьютер в количестве 30 штук
            List<PersonalComputers> moreThanThirtyStock = personalComputers
                .Where(d => d.quantityInStock >= 30)
                .ToList();

            if (moreThanThirtyStock.Count == 0)
            {
                Console.WriteLine("\nНет, отсутствуют ПК в наличии более 30 штук.");
            }

            else
            {
                Console.WriteLine("\nДа, есть. Вот список ПК, количество которых превышает 30 единиц: \n");
                Print.PrintOutput(moreThanThirtyStock);
            }
            #endregion

            Console.ReadKey();
        }
    }
}