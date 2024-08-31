using System;
using System.IO;

namespace Delegates_Events
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Пример сообщений, возникающих при срабатывании событий:");
            FileSearcher fileSearcher = new FileSearcher();
            fileSearcher.FileFound += (sender, e) =>
                {
                    //условие, когда сработает отмена.
                    if (e.Name == "C:\\Windows\\win.ini")
                        fileSearcher.Cancel = true;
                    Console.WriteLine($"Найден файл: {e.Name}");
                };

            try
            {
                fileSearcher.Search(@"C:\Windows");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            Console.WriteLine();
            Console.WriteLine("Пример поиска максимального элемента:");
            DirectoryInfo directory = new DirectoryInfo(@"C:\Windows");
            FileInfo maxFileSize = directory.GetFiles().GetMax(f => f.Length);
            if (maxFileSize != null)
                Console.WriteLine($"Наибольший файл {maxFileSize.FullName} размером {maxFileSize?.Length} байт.");
            Console.WriteLine();
            Console.WriteLine("Нажмите любую клавишу...");
            Console.ReadKey();
        }
    }
}
