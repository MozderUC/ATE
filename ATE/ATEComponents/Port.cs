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

        public void PortConnect(Terminal terminal)
        { 
            if(PortState==false)
            {
                terminal.CallEvent += CallFromTerminal;
                terminal.AnswerEvent += AnswerFromTermiinal;
                terminal.EndCallEvent += EnddCall;
                PortState = true;
            }                        
        }

        public void PortDisconnect(Terminal terminal)
        {
            if(PortState==true)
            {
                terminal.CallEvent -= CallFromTerminal;
                terminal.AnswerEvent -= AnswerFromTermiinal;
                terminal.EndCallEvent -= EnddCall;
                PortState = false;
            }            
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
            IncomingCall?.Invoke(this, e);
        }

        public void AnswerFromTermiinal(object obj, AnswerArgs e)
        {            
            AnswerFromTerminal?.Invoke(this, e);
        }

        public void AnswerToTermiinal(object obj, AnswerArgs e)
        {            
            AnswerToTerminal?.Invoke(this, e);
        }

        public void EnddCall(object obj, EndCallArgs e)
        {            
            EndCall?.Invoke(this, e);
        }

    }
}
