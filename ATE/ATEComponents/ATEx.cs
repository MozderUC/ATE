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
            //port.AnswerEvent += AnswerNumber;          
            //port.EndCallEvent += EndCallNumber;
            customerData.Add(Customer.Number, new Tuple<Port, CustomerData>(port, Customer));
            Terminal terminal = new Terminal(Customer.Number, port);
            return terminal;
        }

        private void CallNumber(object sender, CallArgs e)
        {
            Console.WriteLine("Great you call from number {0}  to number {1}: ",e.TelephoneNumber,e.TargetTelephoneNumber);
                        
            if (customerData[e.TelephoneNumber].Item2.Money > customerData[e.TelephoneNumber].Item2.Rate.CostPerMinute)
            {
                callList.Add(new CallData(e.TelephoneNumber,e.TargetTelephoneNumber,DateTime.Now));                
            }                          
        }


    }
}
