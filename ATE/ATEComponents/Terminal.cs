using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATE.ATEComponents.ArgEvents;
using System.Text.RegularExpressions;

namespace ATE.ATEComponents
{
    class Terminal
    {
        public event EventHandler<CallArgs> CallEvent;
        public event EventHandler<AnswerArgs> AnswerEvent;
        public event EventHandler<EndCallArgs> EndCallEvent;

        public int TerminalNumber { get;private set; }
        public int ID { get;private set; }  
        public Port TerminalPort { get;private set; }

        public Terminal(int number, Port port)
        {
            this.TerminalNumber = number;
            this.TerminalPort = port;
        }


        public void TerminalConnection()
        {
            TerminalPort.Connect(this);
            TerminalPort.IncomingCall += TakeIncomingCall;
            TerminalPort.AnswerToTerminal += TakeAnswer;
        }
        public void Call(int callNumber)
        {
            CallEvent?.Invoke(this, new CallArgs(TerminalNumber, callNumber));
        }

        public void TakeIncomingCall(object sender, CallArgs e)
        {            
            //ID = e.ID;
            Console.WriteLine("Incoming call from number: {0} to terminal {1}", e.TelephoneNumber, e.TargetTelephoneNumber);            
            Console.WriteLine("Y-Answer\nN-Rejekt");
            char k = Char.ToUpper(Console.ReadKey().KeyChar);

            if (k == 'Y')
            {                
                Console.WriteLine();
                AnswerEvent?.Invoke(this, new AnswerArgs(e.TelephoneNumber,e.TargetTelephoneNumber,true));
            }
            else if (k == 'N')
            {                
                Console.WriteLine();
                //EndCall();
            }
                                       
        }

        public void TakeAnswer(object sender, AnswerArgs e)
        {
            //ID = e.Id;
            if (e.StateInCall == true)
            {
                Console.WriteLine("User with number: {0} have answered call from number: {1}", e.TargetTelephoneNumber, e.TelephoneNumber);
            }
            else
            {
                Console.WriteLine("Terminal with number: {0}, have rejected call", e.TelephoneNumber);
            }
        }

        public void EndCall()
        {
            EndCallEvent?.Invoke(this, new EndCallArgs(TerminalNumber));           
        }
    }
}
