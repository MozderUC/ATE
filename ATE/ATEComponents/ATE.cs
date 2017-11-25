using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATE.CustomDataTypes.Emums;
using ATE.CustomDataTypes;
namespace ATE.ATEComponents
{
    class ATE
    {
        private Dictionary<int, Tuple<Port, CustomerData>> customerData;
        private List<CallData> callList = new List<CallData>();

        public Terminal AddATEUser(string firstName,string lastName, RateList rate)
        {
            CustomerData Customer = new CustomerData(firstName, lastName, rate);
            Port Port = new Port();
            //Port.CallEvent += CallNumber;
            //Port.AnswerEvent += AnswerNumber;          
            //Port.EndCallEvent += EndCallNumber;
            customerData.Add(Customer.Number, new Tuple<Port, CustomerData>(Port, Customer));
            var newTerminal = new Terminal(Customer.Number, Port);
            return newTerminal;
        }
               
    }
}
