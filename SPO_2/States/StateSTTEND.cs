using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPO_2
{
    public class StateSTTEND : IAnalizerState
    {
        public void Read(Analizer analizer, char letter)
        {
            if(analizer.isType) // Добавление типа в структуру
            {
                var last = analizer.typesStructs.Last();
                
                var type = analizer.tempWord;
                var size = 0;
                if(analizer.typesC.ContainsKey(analizer.tempType))
                {
                    size = analizer.typesC[analizer.tempType];
                }
                else if(analizer.typesT.ContainsKey(analizer.tempType))
                {
                    size = analizer.typesT[analizer.tempType];
                }
                if (size == 0)
                {
                    analizer.IsError = true;
                }
                last.Value.Add(type, size);
            }
            else
            {
                var last = analizer.dataStructs.Last();
                var name = analizer.tempWord;
                var type = string.Empty;
                if (analizer.typesC.ContainsKey(analizer.tempType))
                {
                    type = analizer.tempType;
                }
                else if (analizer.typesT.ContainsKey(analizer.tempType))
                {
                    type = analizer.tempType;
                }
                else if (analizer.typesStructs.ContainsKey(analizer.tempType))
                {
                    type = analizer.tempType;
                }
                if (type == string.Empty)
                {
                    analizer.IsError = true;
                    return;
                }
                last.Value.Add(name, type);
            }

            analizer.tempType = string.Empty;
            analizer.tempWord = string.Empty;
            if(analizer.escapeSymbols.Contains(letter))
            {
                analizer.State = new StateSTS6();
            }
            else if(letter == ')')
            {
                if(analizer.isType)
                {
                    analizer.State = new StateTEND();
                }
                else
                {
                    analizer.State = new StateVEND();
                }
            }
            else if (char.IsLetter(letter))
            {
                analizer.tempType += letter;
                analizer.State = new StateSTT();
            }
            else
            {
                analizer.IsError = true;
            }
        }
    }
}
