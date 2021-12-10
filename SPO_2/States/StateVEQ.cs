using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPO_2
{
    public class StateVEQ : IAnalizerState
    {
        public void Read(Analizer analizer, char letter)
        {
            if(analizer.escapeSymbols.Contains(letter))
            {
                analizer.State = new StateVS2();
            }
            else if(char.IsLetter(letter))
            {
                analizer.tempType += letter;
                analizer.State = new StateVT();
            }
            else
            {
                analizer.IsError = true;
            }
        }
    }
}
