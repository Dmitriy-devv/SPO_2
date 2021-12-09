using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPO_2
{
    public class StateTN1 : IAnalizerState
    {
        public void Read(Analizer analizer, char letter)
        {
            if(analizer.escapeSymbols.Contains(letter))
            {
                analizer.State = new StateTS1();
            }
            else if(char.IsLetter(letter))
            {
                analizer.tempWord += letter;
                analizer.State = this;
            }
            else if(letter == '=')
            {
                analizer.State = new StateTEQ();
            }
            else
            {
                analizer.IsError = true;
            }
        }
    }
}
