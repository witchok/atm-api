using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATMBankWebAPI.Exceptions
{
    public class WrongPinException : Exception
    {
        public WrongPinException()
        {

        }
        public WrongPinException(string msg) : base(msg)
        {

        }
    }
}
