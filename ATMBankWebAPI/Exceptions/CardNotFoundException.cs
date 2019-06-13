using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATMBankWebAPI.Exceptions
{
    public class CardNotFoundException: Exception
    {
        public CardNotFoundException()
        {
        }
        public CardNotFoundException(string msg):base(msg)
        {
        }
    }
}
