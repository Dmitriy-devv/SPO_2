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
            Space();

            //Этап 1 - Лексический анализатор
            var analizer = new Analizer(code, new StateN());
            analizer.Analize();
            if (analizer.IsError)
            {
                Console.WriteLine(analizer.ErrorMsg);
            }
            foreach(var word in analizer.typesT)
            {
                Console.WriteLine(word.Key + "  " + word.Value);
            }
            foreach (var word in analizer.typesStructs)
            {
                Console.WriteLine(word.Key + " is struct");
            }
            Console.WriteLine(analizer.tempWord + " is tempWord");
            Console.WriteLine(analizer.tempType + " is tempType");
            //Этап 2 - Вычисление объёма данных



            Console.ReadKey();

        }

        private static void Space()
        {
            Console.WriteLine("------------------------------------------");
        }
    }
}
