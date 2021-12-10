using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPO_2
{
    public class StateVEND : IAnalizerState
    {
        public void Read(Analizer analizer, char letter)
        {
            if (analizer.isStruct)
            {
                analizer.isStruct = false;

            }
            else
            {
                if (analizer.typesC.ContainsKey(analizer.tempType))
                {
                    analizer.dataT.Add(analizer.tempWord, analizer.tempType);
                }
                else if (analizer.typesT.ContainsKey(analizer.tempType))
                {
                    analizer.dataT.Add(analizer.tempWord, analizer.tempType);
                }
                else if (analizer.typesStructs.ContainsKey(analizer.tempType))
                {
                    analizer.dataT.Add(analizer.tempWord, analizer.tempType);
                }
                else
                {
                    analizer.IsError = true;
                    return;
                }
            }



            analizer.tempType = string.Empty;
            analizer.tempWord = string.Empty;
            if (analizer.escapeSymbols.Contains(letter))
            {
                analizer.State = new StateV();
            }
            else if(char.IsLetter(letter))
            {
                analizer.tempWord += letter;
                analizer.State = new StateVW();
            }
            else
            {
                analizer.IsError = true;
            }
        }
    }
}
