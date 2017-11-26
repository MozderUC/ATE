using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATE.CustomDataTypes.Emums;

namespace ATE.CustomDataTypes
{
    class Rate
    {       
        public int CostPerMinute { get; private set; }
        public int CostOfMonth { get; private set; }                
        public RateList Rates { get; private set; }

        public Rate(RateList rate)
        {
            switch (rate)
            {
                case RateList.Lite:
                    {
                        CostPerMinute = 4;
                        CostOfMonth = 10;
                        break;
                    }
                case RateList.Mini:
                    {
                        CostPerMinute = 3;
                        CostOfMonth = 20;
                        break;
                    }
                case RateList.Standart:
                    {
                        CostPerMinute = 2;
                        CostOfMonth = 30;
                        break;
                    }
                case RateList.Advanced:
                    {
                        CostPerMinute = 1;
                        CostOfMonth = 40;
                        break;
                    }
            }
        }
    }
}
