using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPO_2
{
    public class StateTS : IAnalizerState
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
                analizer.State = new StateTN1();
            }
            else
            {
                analizer.IsError = true;
            }
        }
    }
}
