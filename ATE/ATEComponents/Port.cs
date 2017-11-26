using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATE.ATEComponents.ArgEvents;

namespace ATE.ATEComponents
{
    class Port
    {
        public event EventHandler<CallArgs> CallEvent;


        public void Connect(Terminal terminal)
        {
            //State = PortState.Connect;
            terminal.CallEvent += CallFromTerminal;
            //terminal.AnswerEvent += AnswerTo;
            //terminal.EndCallEvent += EndCall;
            //Flag = true;
            
            //return Flag;
        }

        protected void CallFromTerminal(object obj, CallArgs e)
        {
            if (CallEvent != null)
            {
                CallEvent(this, e);
            }
            //CallEvent?.Invoke(this, e);
        }
    }
}
