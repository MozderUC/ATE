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
        public bool PortState { get;private set; }

        public event EventHandler<CallArgs> CallEvent;
        public event EventHandler<CallArgs> IncomingCall;        
        public event EventHandler<AnswerArgs> AnswerFromTerminal;
        public event EventHandler<AnswerArgs> AnswerToTerminal;
        public event EventHandler<EndCallArgs> EndCall;

        public void Connect(Terminal terminal)
        {
            //State = PortState.Connect;
            terminal.CallEvent += CallFromTerminal;
            terminal.AnswerEvent += AnswerFromTermiinal;
            terminal.EndCallEvent += EnddCall;
            //Flag = true;

            PortState = true;
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

        public void IncommingCall(object obj, CallArgs e)
        {
            if (CallEvent != null)
            {
                IncomingCall(this, e);
            }
            //IncomingCall?.Invoke(this, e);
        }

        public void AnswerFromTermiinal(object obj, AnswerArgs e)
        {
            if (AnswerFromTerminal != null)
            {
                AnswerFromTerminal(this, e);
            }
            //AnswerFromTerminal?.Invoke(this, e);
        }

        public void AnswerToTermiinal(object obj, AnswerArgs e)
        {
            if (AnswerToTerminal != null)
            {
                AnswerToTerminal(this, e);
            }
            //AnswerToTerminal?.Invoke(this, e);
        }

        public void EnddCall(object obj, EndCallArgs e)
        {
            if (EndCall != null)
            {
                EndCall(this, e);
            }
            //EndCall?.Invoke(this, e);
        }

    }
}
