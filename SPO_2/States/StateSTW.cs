using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPO_2
{
    public class StateSTW : IAnalizerState
    {
        public void Read(Analizer analizer, char letter)
        {
            if(analizer.escapeSymbols.Contains(letter))
            {
                analizer.State = new StateSTS5();
            }
            else if(char.IsLetter(letter))
            {
                analizer.tempWord += letter;
            }
            else if(letter == ';')
            {
                analizer.State = new StateSTTEND();
            }
            else
            {
                analizer.IsError = true;
            }
        }
    }
}
