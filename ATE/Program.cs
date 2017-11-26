using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using ATE.ATEComponents;
using ATE.CustomDataTypes.Emums;

namespace ATE
{
    class Program
    {
        static void Main(string[] args)
        {
            ATEx ate = new ATEx();
            Port port = new Port();

            Terminal term1 = ate.AddATEUser("Vlad", "Sidorov", RateList.Mini);
            Terminal term2 = ate.AddATEUser("Karl", "Petrov", RateList.Lite);

            term1.TerminalConnection();
            term2.TerminalConnection();
                    
            term1.Call(term2.TerminalNumber);
            Thread.Sleep(2000);

            term1.EndCall();
            //term2.EndCall();

        }
    }
}
