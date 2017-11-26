using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATE.ATEComponents.ArgEvents
{
    class EndCallArgs
    {
        //public int Id { get; private set; }
        public int TelephoneNumber { get; private set; }
        
        public EndCallArgs(int number)
        {            
            TelephoneNumber = number;
        }
    }
}
