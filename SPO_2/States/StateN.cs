using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPO_2
{
    public class StateN : IAnalizerState
    {
        public void Read(Analizer analizer, char letter)
        {
            if(analizer.escapeSymbols.Contains(letter))
            {
                analizer.State = this;
            }
            else if(char.IsLetter(letter))
            {
                analizer.tempWord += letter;
                analizer.State = new StateT();
            }
            else
            {
                analizer.IsError = true;
            }
        }
    }
}
