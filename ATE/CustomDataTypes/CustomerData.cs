using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATE.CustomDataTypes.Emums;

namespace ATE.CustomDataTypes
{
    class CustomerData
    {       
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int Money { get; private set; } 
        public int Number { get; private set; }
        public Rate Rate { get; private set; }


        private DateTime TariffUpdateDate;
        static Random random = new Random();

        public CustomerData(string firstName, string lastName, RateList rate, int money=10)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Money = money;
            this.Number = random.Next(1000000, 9999999);
            TariffUpdateDate = DateTime.Now;                       
            this.Rate = new Rate(rate);
        }
          
           
    }
}
