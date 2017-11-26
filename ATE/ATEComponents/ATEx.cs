using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATE.CustomDataTypes.Emums;
using ATE.CustomDataTypes;
using ATE.ATEComponents.ArgEvents;

namespace ATE.ATEComponents
{
    class ATEx
    {
        private Dictionary<int, Tuple<Port, CustomerData>> customerData = new Dictionary<int, Tuple<Port, CustomerData>>();
        private List<CallData> callList = new List<CallData>();

        public Terminal AddATEUser(string firstName,string lastName, RateList rate)
        {
            CustomerData Customer = new CustomerData(firstName, lastName, rate);
            Port port = new Port();
            port.CallEvent += CallNumber;
            port.AnswerFromTerminal += AnswerNumber;          
            port.EndCall += EndCall;
            customerData.Add(Customer.Number, new Tuple<Port, CustomerData>(port, Customer));
            Terminal terminal = new Terminal(Customer.Number, port);
            return terminal;
        }

        private void CallNumber(object sender, CallArgs e)
        {                                   
            if ((customerData.ContainsKey(e.TargetTelephoneNumber) && e.TargetTelephoneNumber != e.TelephoneNumber))
            {
                if (customerData[e.TelephoneNumber].Item1.PortState == true && customerData[e.TargetTelephoneNumber].Item1.PortState == true)
                {
                    if (customerData[e.TelephoneNumber].Item2.Money > customerData[e.TelephoneNumber].Item2.Rate.CostPerMinute)
                    {
                        callList.Add(new CallData(e.TelephoneNumber, e.TargetTelephoneNumber, DateTime.Now));
                        customerData[e.TargetTelephoneNumber].Item1.IncommingCall(this,new CallArgs(e.TelephoneNumber,e.TargetTelephoneNumber));
                    }
                    else
                    {
                        Console.WriteLine("We don't have enough money to make the call");
                    }
                }
                else
                {
                    Console.WriteLine("The subscriber is not available now, please call back later");
                }                    
            }
            else
            {
                Console.WriteLine("Number is not exist, please check the number and call again.");
            }                                                     
        }

        private void AnswerNumber(object sender, AnswerArgs e)
        {
            //Console.WriteLine("Great number {1}  answer for number {0}: ", e.TelephoneNumber, e.TargetTelephoneNumber);
            customerData[e.TelephoneNumber].Item1.AnswerToTermiinal(this, e);
        }

        private void EndCall(object sender, EndCallArgs e)
        {                                   
            CallData callData = callList.Find(x => (x.EndCall.Equals(new DateTime())&&(x.MyNumber==e.TelephoneNumber||x.TargetNumber==e.TelephoneNumber)));
            if (!(callData == null))
            {
                Rate rate = customerData[callData.MyNumber].Item2.Rate;
                callData.EndCall = DateTime.Now;
                int cost = Convert.ToInt32(rate.CostPerMinute * TimeSpan.FromTicks((callData.EndCall - callData.BeginCall).Ticks).TotalSeconds);
                callData.Cost = cost;
                customerData[callData.MyNumber].Item2.RemoveMoney(callData.Cost);
                customerData[e.TelephoneNumber].Item1.AnswerToTermiinal(this, new AnswerArgs(e.TelephoneNumber, callData.TargetNumber, false));

            }                
        }
    }
}
