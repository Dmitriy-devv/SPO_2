using System;

namespace SPO_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"C:\SPO\note2.txt";
            var textReader = new TextReader(path);
            var code = textReader.Read();
            Console.WriteLine($"Текст из файла:\n{code} ");
            Console.Write('\n');
            //Этап 1 - Лексический анализатор
            var analizer = new Analizer(code, new StateN());
            analizer.Analize();
            if (analizer.IsError)
            {
                Console.WriteLine($"Возникла ошибка при чтение текста: {analizer.ErrorMsg}");
                return;
            }
            Console.WriteLine("------------------------------------------");

            analizer.ConsoleTypes();

            analizer.ConsoleData();



            //Этап 2 - Вычисление объёма данных

            Console.ReadKey();

        }

    }
}
