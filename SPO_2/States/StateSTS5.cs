﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPO_2
{
    public class StateSTS5 : IAnalizerState
    {
        public void Read(Analizer analizer, char letter)
        {
            if(analizer.escapeSymbols.Contains(letter))
            {
                analizer.State = this;
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
