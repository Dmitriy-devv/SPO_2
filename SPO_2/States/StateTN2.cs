using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPO_2
{
    public class StateTN2 : IAnalizerState
    {
        public void Read(Analizer analizer, char letter)
        {
            if(analizer.escapeSymbols.Contains(letter))
            {
                analizer.State = new StateTS3();
            }
            else if(char.IsLetter(letter))
            {
                analizer.tempType += letter;
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
