using System;

/// Создаем свой тип исключения
public class InvalidInputException : Exception
{
    public InvalidInputException(string message) : base(message)
    {
    }
}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            /// Создаем массив исключений разных типов
            var exceptions = new Exception[]
            {
                new DivideByZeroException(),
                new IndexOutOfRangeException(),
                new ArgumentNullException(),
                new InvalidInputException("Свое исключение"),
                new InvalidOperationException()
            };

            /// Итерация по массиву исключений
            foreach (var exception in exceptions)
            {
                try
                {
                    /// Генерируем исключение
                    throw exception;
                }
                catch (DivideByZeroException)
                {
                    Console.WriteLine("Поймано исключение DivideByZeroException");
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Поймано исключение IndexOutOfRangeException");
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Поймано исключение ArgumentNullException");
                }
                catch (InvalidInputException ex)
                {
                    Console.WriteLine("Поймано собственное исключение InvalidInputException: " + ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Поймано общее исключение: " + ex.GetType().Name);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Поймано исключение во внешнем блоке catch: " + ex.GetType().Name);
        }
    }
}