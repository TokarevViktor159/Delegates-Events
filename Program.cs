using System;
using System.Collections.Generic;

namespace Delegates_Events
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Пример сообщений, возникающих при срабатывании событий:");
            FileSearcher FS = new FileSearcher();
            FS.FileFound += FS_FileFound;

            try
            {
                FS.Search(@"C:\Windows");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            Console.WriteLine();
            Console.WriteLine("Пример поиска максимального элемента:");
            List<Test> tests = new List<Test>()
            {
                new Test() { Value = 1.5f },
                new Test() { Value = 2.5f },
                new Test() { Value = 3.5f },
                new Test() { Value = 0.5f }
            };
            Test max_item = tests.GetMax(f => f.Value);
            Console.WriteLine($"Max значение: {max_item?.Value}");
            Console.WriteLine();
            Console.WriteLine("Нажмите любую клавишу...");
            Console.ReadKey();
        }

        private static void FS_FileFound(object sender, FileArgs e)
        {
            Console.WriteLine($"Найден файл: {e.Name}");
        }

        public class Test
        {
            public float Value { get; set; }
        }
    }
}
