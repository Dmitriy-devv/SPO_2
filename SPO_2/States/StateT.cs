using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPO_2
{
    public class StateT : IAnalizerState
    {
        public void Read(Analizer analizer, char letter)
        {
            if (analizer.escapeSymbols.Contains(letter))
            {
                if (analizer.tempWord != "type")
                {
                    analizer.IsError = true;
                    return;
                }
                analizer.tempWord = string.Empty;
                analizer.State = new StateTS();
            }
            else if (char.IsLetter(letter))
            {
                analizer.tempWord += letter;
                analizer.State = this;
            }
            else
            {
                analizer.IsError = true;
            }
        }
    }
}
