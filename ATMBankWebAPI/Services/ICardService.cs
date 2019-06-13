using ATMBankDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ATMBankWebAPI.Services
{
    public interface ICardService
    {
        Card GetBankCard(string pin, string cardNumber);
        Card GetBankCard(int? id);
        Card GetBankCard(Expression<Func<Card, bool>> where);
        IEnumerable<Card> GetSome(Expression<Func<Card, bool>> where);
        IEnumerable<Card> GetAll();
        IEnumerable<BankTransaction> GetAllCardTransactions(string cardNumber, string pin);
    }
}
