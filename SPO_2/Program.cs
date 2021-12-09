using System;

namespace SPO_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"C:\SPO\note.txt";
            var textReader = new TextReader(path);
            var code = textReader.Read();

            //Этап 1 - Лексический анализатор


            Console.ReadKey();

        }

        private static void Space()
        {
            Console.WriteLine("------------------------------------------");
        }
    }
}
