using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATMBankWebAPI.Exceptions
{
    public class CardNotValidException : Exception
    {
        public CardNotValidException()
        {

        }
        
        public CardNotValidException(string msg):base(msg)
        {

        }
    }
}
