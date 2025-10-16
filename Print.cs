using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    static class Print
    {
        static public void PrintOutput(List<PersonalComputers> personalComputers)
        {
            foreach (PersonalComputers print in personalComputers)
            {
                Console.WriteLine($"ID: {print.Id} | Бренд: {print.computerBrand} | Процессор: {print.processorType} | Частота: {print.operatingFrequency}MHz");
                Console.WriteLine($"     ОЗУ: {print.amountOfRandomAccessMemory}GB | Жёсткий диск: {print.hardDriveCapacity}GB | Видеокарта: {print.videoCardMemoryCapacity}GB | Стоимость: {print.computerCost} | В наличии: {print.quantityInStock} шт.");
                Console.WriteLine("----------------------------------------------------------------------------------------------------------------\n");
            }
        }

        static public void PrintGroup(IEnumerable<IGrouping<string, PersonalComputers>> processorGroup)
        {
            foreach (IGrouping<string, PersonalComputers> group in processorGroup)
            {
                Console.WriteLine($"\n Процессор: {group.Key}");
                Console.WriteLine("-------------------------------------------");

                foreach (PersonalComputers computer in group)
                {
                    Console.WriteLine($"ID: {computer.Id} | Бренд: {computer.computerBrand} | Частота: {computer.operatingFrequency}MHz");
                    Console.WriteLine($"     ОЗУ: {computer.amountOfRandomAccessMemory}GB | Жёсткий диск: {computer.hardDriveCapacity}GB | Стоимость: {computer.computerCost}₽");
                    Console.WriteLine("-------------------------------------------");
                }

                Console.WriteLine($"Всего компьютеров с процессором {group.Key}: {group.Count()}");
            }
        }

        static public void SimpleOutput(PersonalComputers mostExpensive, PersonalComputers mostBudget)
        {
            Console.WriteLine("\nСамый дорогой ПК: ");
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine($"ID: {mostExpensive.Id} | Бренд: {mostExpensive.computerBrand} | Частота: {mostExpensive.operatingFrequency}MHz");
            Console.WriteLine($"     ОЗУ: {mostExpensive.amountOfRandomAccessMemory}GB | Жёсткий диск: {mostExpensive.hardDriveCapacity}GB | Стоимость: {mostExpensive.computerCost}");
            Console.WriteLine("-------------------------------------------");

            Console.WriteLine("\n Самый бюджетный ПК: ");
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine($"ID: {mostBudget.Id} | Бренд: {mostBudget.computerBrand} | Частота: {mostBudget.operatingFrequency}MHz");
            Console.WriteLine($"     ОЗУ: {mostBudget.amountOfRandomAccessMemory}GB | Жёсткий диск: {mostBudget.hardDriveCapacity}GB | Стоимость: {mostBudget.computerCost}");
            Console.WriteLine("-------------------------------------------\n");
        }
    }
}
