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

            #region UserInitialization
            Terminal term1 = ate.AddATEUser("Vlad", "Sidorov", RateList.Mini);
            Terminal term2 = ate.AddATEUser("Karl", "Petrov", RateList.Lite);
            Terminal term3 = ate.AddATEUser("Masha", "Smirnova", RateList.Lite);
            Terminal term4 = ate.AddATEUser("Petia", "Petrov", RateList.Lite);
            Terminal term5 = ate.AddATEUser("Zosia", "Karlovna", RateList.Lite);
            #endregion

            #region PortConnection
            term1.TerminalConnection();
            term2.TerminalConnection();
            term3.TerminalConnection();
            term4.TerminalConnection();
            term5.TerminalConnection();
            #endregion


            //term1.Call(1312412);
            term1.Call(term2.TerminalNumber);
            Thread.Sleep(4000);
            term2.EndCall();

            term3.Call(term4.TerminalNumber);
            Thread.Sleep(2000);
            term4.EndCall();

            term5.Call(term1.TerminalNumber);
            Thread.Sleep(2000);
            term1.EndCall();                              

            
            Console.WriteLine();

        }
    }
}
