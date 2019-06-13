using ATMBankDAL.Models;
using ATMBankWebAPI.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATMBankWebAPI.Mapping
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<BankTransaction, TransactionModel>()
                .ForMember(tm => tm.RecipientCardNumber, opt => opt.MapFrom(bt => bt.RecipientCard.Number))
                .ForMember(tm => tm.SenderCardNumber, opt => opt.MapFrom(bt => bt.SenderCard.Number));
            CreateMap<CardOwner, CardOwnerModel>();

            CreateMap<Card, CardModel>();
                //.ForMember(cm => cm.ReceivedTransactions,
                //opt => opt.MapFrom(
                //    c => Mapper.Map<IEnumerable<BankTransaction>, IEnumerable<TransactionModel>>(c.ReceivedTransactions)))
                //.ForMember(cm => cm.SentTransactions,
                //    opt => opt.MapFrom(
                //    c => Mapper.Map<IEnumerable<BankTransaction>, IEnumerable<TransactionModel>>(c.SentTransactions)));
        }
    }
}
