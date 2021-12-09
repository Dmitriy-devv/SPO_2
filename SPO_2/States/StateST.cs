using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPO_2
{
    public class StateST : IAnalizerState
    {
        public void Read(Analizer analizer, char letter)
        {
            if(analizer.escapeSymbols.Contains(letter))
            {
                analizer.State = new StateSTS1();
            }
            else if(letter == '(')
            {
                analizer.State = new StateSTB1();
                analizer.IsError = true;
            }
            else
            {
                analizer.IsError = true;
            }
        }
    }
}
