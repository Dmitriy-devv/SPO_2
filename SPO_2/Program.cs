using System;

namespace SPO_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Чтение из файла
            var path = @"C:\SPO\note2.txt";
            var textReader = new TextReader(path);
            var code = textReader.Read();

            //Вывод текста из файла
            Console.WriteLine($"Текст из файла:\n{code} ");
            Console.Write('\n');

            //Этап 1 - Лексический анализатор
            var analizer = new Analizer(code, new StateN());
            // Анализ текста
            analizer.Analize();
            if (analizer.IsError)
            {
                Console.WriteLine($"Возникла ошибка при чтение текста: {analizer.ErrorMsg}");
                return;
            }
            Console.WriteLine("------------------------------------------");


            // Этап 2 - Вычисление объёма данных

            // Вывод типов
            analizer.ConsoleTypes();
            // Вывод переменных
            analizer.ConsoleData();
            // Вывод переменных с учетом кратности
            analizer.ConsoleDataMultiplicity();

            Console.ReadKey();

        }

    }
}
