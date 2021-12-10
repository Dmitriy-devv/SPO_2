using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPO_2
{
    public class StateTS1 : IAnalizerState
    {
        public void Read(Analizer analizer, char letter)
        {
            if(analizer.escapeSymbols.Contains(letter))
            {
                if(analizer.tempWord == "var")
                {
                    analizer.tempWord = string.Empty;
                    analizer.tempType = string.Empty;
                    analizer.isType = false;
                    analizer.State = new StateV();
                    return;
                }
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
