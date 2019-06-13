using ATMBankDAL.Data.Repositories.Cards;
using ATMBankDAL.Models;
using ATMBankWebAPI.Exceptions;
using StringEncoding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ATMBankWebAPI.Services
{
    public class CardService : ICardService
    {
        private readonly ICardRepository _repo;
        public CardService(ICardRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<Card> GetAll()
        {
            return _repo.GetAll();
        }

        public IEnumerable<BankTransaction> GetAllCardTransactions(string cardNumber, string pin)
        {
            var card = this.GetBankCard(cardNumber, pin);
            return card.SentTransactions
                .Concat(card.ReceivedTransactions)
                .OrderByDescending(t => t.ExecutionDate);
        }

        public Card GetBankCard(string cardNumber, string pin)
        {
            if (!IsCardNumberValid(cardNumber))
            {
                throw new CardNotValidException("Card number isn't valid");
            }

            if (!IsPinValid(pin))
            {
                throw new PinNotValidException("PIN isn't valid");
            }

            var card = _repo.GetOne(cardNumber);

            if (card == null)
            {
                throw new CardNotFoundException($"Card with number {cardNumber} isn't found");
            }

            if (card.EncodedPin.DecodeForUTF8() != pin)
            {
                throw new WrongPinException("Wrong PIN");
            }

            return card;
        }

        public Card GetBankCard(int? id)
        {
            return _repo.GetOne(id);
        }

        public Card GetBankCard(Expression<Func<Card, bool>> where)
        {
            return _repo.GetOne(where);
        }

        public IEnumerable<Card> GetSome(Expression<Func<Card, bool>> where)
        {
            return _repo.GetSome(where);
        }

        private bool IsCardNumberValid(string cardNumber)
        {
            return (cardNumber.Length == 16 && long.TryParse(cardNumber, out long _));
        }

        private bool IsPinValid(string pin)
        {
            return (pin.Length == 4 && int.TryParse(pin, out int _));
        }

    }
}
