using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPO_2
{
    public class StateVS3 : IAnalizerState
    {
        public void Read(Analizer analizer, char letter)
        {
            if (analizer.tempType == "struct")
            {
                analizer.isStruct = true;
                analizer.dataStructs.Add(analizer.tempWord, new());

                analizer.tempWord = string.Empty;
                analizer.tempType = string.Empty;
                analizer.State = new StateST();
                return;
            }

            if (analizer.escapeSymbols.Contains(letter))
            {
                analizer.State = this;
            }
            else if (letter == ';')
            {
                analizer.State = new StateVEND();
            }
            else
            {
                analizer.IsError = true;
            }
        }
    }
}
