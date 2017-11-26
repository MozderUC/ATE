using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATE.ATEComponents.ArgEvents;

namespace ATE.ATEComponents
{
    class Terminal
    {
        public event EventHandler<CallArgs> CallEvent;
        //public event EventHandler<AnswerArgs> AnswerEvent;
        //public event EventHandler<EndCallArgs> EndCallEvent;
        public int TerminalNumber { get;private set; }
        public Port TerminalPort { get;private set; }

        public Terminal(int number, Port port)
        {
            this.TerminalNumber = number;
            this.TerminalPort = port;
        }


        public void TerminalConnection()
        {
            TerminalPort.Connect(this);
        }
        public void Call(int callNumber)
        {
            CallEvent?.Invoke(this, new CallArgs(TerminalNumber, callNumber));
        }
    }
}
