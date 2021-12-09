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
        public Dictionary<string, Dictionary<string, int>> typesStructs = new();
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
            foreach(var symbol in Code)
            {
                Console.WriteLine(State);
                Console.WriteLine(symbol);
                State.Read(this, symbol);
                if (IsError) return;
            }
        }
       

    }
}
