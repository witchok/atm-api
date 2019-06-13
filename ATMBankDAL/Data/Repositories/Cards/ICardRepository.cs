using ATMBankDAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATMBankDAL.Data.Repositories.Cards
{
    public interface ICardRepository : IRepository<Card>
    {
        Card GetOne(string number);
    }
}
