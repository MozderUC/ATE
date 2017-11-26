using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATE.ATEComponents.ArgEvents
{
    class CallArgs : EventArgs
    {
        public int TelephoneNumber { get; private set; }
        public int TargetTelephoneNumber { get; private set; }       
        public CallArgs(int number, int target)
        {
            TelephoneNumber = number;
            TargetTelephoneNumber = target;
        }       
    }
}
