using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPO_2
{
    public class StateSTT : IAnalizerState
    {
        public void Read(Analizer analizer, char letter)
        {
            if(analizer.escapeSymbols.Contains(letter))
            {
                analizer.State = new StateSTS3();
            }
            else if(char.IsLetterOrDigit(letter))
            {
                analizer.tempType += letter;
            }
            else if(letter == ':')
            {
                analizer.State = new StateSTEQ();
            }
            else
            {
                analizer.IsError = true;
            }
        }
    }
}
