using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATMBankWebAPI.Exceptions
{
    public class PinNotValidException : Exception
    {
        public PinNotValidException()
        {

        }

        public PinNotValidException(string msg) : base(msg)
        {

        }
    }
}
