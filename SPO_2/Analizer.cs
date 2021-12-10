using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPO_2
{
    public class Analizer
    {
        private string Code { get; init; }
        public IAnalizerState State { get; set; }
        private bool isError;
        public bool IsError 
        { 
            get
            {
                return isError;
            }
            set
            {
                isError = value;
                ErrorMsg = "State is " + State.ToString();
            }
        }
        public string ErrorMsg { get; private set; }

        public bool isType = true;

        public List<char> escapeSymbols = new()
        {
            '\t',
            '\n',
            ' ',
            '\r'
        };

        public Dictionary<string, int> typesC = new()
        {
            {"byte", 1},
            {"word", 2}
        };

        public Dictionary<string, int> typesT = new();
        public Dictionary<string, string> dataT = new();
        public Dictionary<string, Dictionary<string, int>> typesStructs = new();
        public Dictionary<string, Dictionary<string, string>> dataStructs = new();
        public Dictionary<string, int> tempStruct = new();
        public string tempWord;
        public string tempType;
        public bool isStruct;
        public Analizer(string code, IAnalizerState state)
        {
            Code = code;
            State = state;
        }

        public void Analize()
        {
            
            foreach (var symbol in Code)
            {
                if (IsError) return;
                State.Read(this, symbol);
            }
            
        }
        
        public void ConsoleTypes()
        {
            Console.WriteLine($"\nTypes");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine($"Name\t\tSize\tData type");
            Console.WriteLine("------------------------------------------");
            foreach (var word in typesT)
            {
                if(word.Key.Length < 8)
                {
                    Console.WriteLine($"{word.Key}\t\t{word.Value}\tvariable");
                }
                else
                {
                    Console.WriteLine($"{word.Key}\t{word.Value}\tvariable");
                }
            }
            foreach (var word in typesStructs)
            {
                var size = 0;
                foreach(var element in word.Value)
                {
                    size += element.Value;
                }
                if (word.Key.Length < 8)
                {
                    Console.WriteLine($"{word.Key}\t\t{size}\tstruct");
                }
                else
                {
                    Console.WriteLine($"{word.Key}\t\t{size}\tstruct");
                }
                
            }
            Console.WriteLine("------------------------------------------");
        }

        public void ConsoleData()
        {
            Console.WriteLine($"\nVariables");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine($"Name\t\tSize\tData type");
            Console.WriteLine("------------------------------------------");
            foreach (var word in dataT)
            {
                Console.WriteLine($"{word.Key}\t\t{Size(word.Value)}\t{word.Value}");
            }
            foreach (var word in dataStructs)
            {
                var size = 0;
                foreach(var element in word.Value)
                {
                    size += Size(element.Value);
                }
                
                Console.WriteLine($"{word.Key}\t\t{size}\tstruct");
            }
            Console.WriteLine("------------------------------------------");
        }

        public int Size(string type)
        {
            var size = 0;
            if (typesC.ContainsKey(type))
            {
                size = typesC[type];
            }
            else if (typesT.ContainsKey(type))
            {
                size = typesT[type];
            }
            else if (typesStructs.ContainsKey(type))
            {
                var st = typesStructs[type];
                foreach (var element in st)
                {
                    size += element.Value;
                }
            }
            return size;
        }

    }
}
