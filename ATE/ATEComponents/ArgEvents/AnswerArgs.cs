using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATE.ATEComponents.ArgEvents
{
    class AnswerArgs
    {
        public int TelephoneNumber { get; private set; }
        public int TargetTelephoneNumber { get; private set; }
        public bool StateInCall;
        //public int Id { get; private set; }
        public AnswerArgs(int number, int target, bool state)
        {
            TelephoneNumber = number;
            TargetTelephoneNumber = target;
            StateInCall = state;
        }
        /*
        public AnswerArgs(int number, int target, bool state, int id)
        {
            TelephoneNumber = number;
            TargetTelephoneNumber = target;
            StateInCall = state;
            Id = id;
        }
        */
    }
}
