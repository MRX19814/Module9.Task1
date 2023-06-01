using System;
using System.Collections.Generic;

/// Создаем свой тип исключения
public class InvalidInputException : Exception
{
    public InvalidInputException(string message) : base(message)
    {
    }
}

class Program
{
    /// Событие для сортировки списка фамилий
    public static event Action<List<string>, bool> SortNamesEvent;

    static void Main(string[] args)
    {
        List<string> names = new List<string> { "Иванов", "Петров", "Сидоров", "Козлов", "Смирнов" };

        SortNamesEvent += SortNames;

        try
        {
            while (true)
            {
                Console.WriteLine("Введите число 1 для сортировки А-Я или число 2 для сортировки Я-А:");
                string input = Console.ReadLine();

                try
                {
                    /// Проверка введенных данных и генерация события
                    if (input == "1")
                    {
                        SortNamesEvent?.Invoke(names, true);
                        break;
                    }
                    else if (input == "2")
                    {
                        SortNamesEvent?.Invoke(names, false);
                        break;
                    }
                    else
                    {
                        throw new InvalidInputException("Некорректный ввод. Введите число 1 или 2.");
                    }
                }
                catch (InvalidInputException ex)
                {
                    Console.WriteLine("Ошибка: " + ex.Message);
                }
                finally
                {
                    Console.WriteLine("Блок finally выполнен.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Поймано исключение: " + ex.GetType().Name);
        }
        finally
        {
            Console.WriteLine("Блок finally во внешнем блоке catch выполнен.");
        }

        /// Вывод отсортированного списка фамилий
        Console.WriteLine("Отсортированный список фамилий:");
        foreach (var name in names)
        {
            Console.WriteLine(name);
        }
    }

    /// Метод для сортировки списка фамилий
    static void SortNames(List<string> names, bool ascending)
    {
        if (ascending)
        {
            names.Sort();
        }
        else
        {
            names.Sort((x, y) => y.CompareTo(x));
        }
    }
}