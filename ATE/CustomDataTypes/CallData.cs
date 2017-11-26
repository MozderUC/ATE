using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATE.CustomDataTypes
{
    class CallData
    {      
        public int MyNumber { get; set; }
        public int TargetNumber { get; set; }
        public DateTime BeginCall { get; set; }
        public DateTime EndCall { get; set; }
        public int Cost { get; set; }

        public CallData(int myNumber, int targetNumber, DateTime beginCall)
        {           
            MyNumber = myNumber;
            TargetNumber = targetNumber;
            BeginCall = beginCall;
        }
    }
}
