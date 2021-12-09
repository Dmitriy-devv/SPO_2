using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPO_2
{
    public class StateTS3 : IAnalizerState
    {
        public void Read(Analizer analizer, char letter)
        {
            if(analizer.escapeSymbols.Contains(letter))
            {
                if(analizer.tempType == "struct")
                {
                    analizer.isStruct = true;
                    analizer.typesStructs.Add(analizer.tempWord, new());
                    analizer.State = new StateST();
                    analizer.tempWord = string.Empty;
                    analizer.tempType = string.Empty;
                    return;
                }
                analizer.State = this;
            }
            else if(letter == ';')
            {
                analizer.State = new StateTEND();
            }
            else
            {
                analizer.IsError = true;
            }
        }
    }
}
