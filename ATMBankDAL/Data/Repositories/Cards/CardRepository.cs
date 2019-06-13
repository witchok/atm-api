using ATMBankDAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATMBankDAL.Data.Repositories.Cards
{
    public class CardRepository : BaseRepository<Card>, ICardRepository
    {
        public Card GetOne(string number) => GetOne(c => c.Number == number);
    }
}
