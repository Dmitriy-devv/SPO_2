using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPO_2
{
    public class StateTEND : IAnalizerState
    {
        public void Read(Analizer analizer, char letter)
        {
            if (analizer.isStruct)
            {

            }
            else
            {
                if(analizer.typesC.ContainsKey(analizer.tempType))
                {
                    analizer.typesT.Add(analizer.tempWord, analizer.typesC[analizer.tempType]);
                }
            }

            analizer.tempWord = string.Empty;
            analizer.tempType = string.Empty;

            if(analizer.escapeSymbols.Contains(letter))
            {
                analizer.State = new StateTS();
            }
            else if(char.IsLetter(letter))
            {
                analizer.tempWord += letter;
                analizer.State = new StateTN1();
            }
            else
            {
                analizer.IsError = true;
            }
        }
    }
}
