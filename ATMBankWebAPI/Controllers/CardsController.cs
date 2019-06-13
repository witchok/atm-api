using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ATMBankDAL.Data;
using ATMBankDAL.Models;
using AutoMapper;
using ATMBankWebAPI.Models;
using StringEncoding;
using Microsoft.AspNetCore.Cors;
using ATMBankWebAPI.Exceptions;
using ATMBankDAL.Data.Repositories.Cards;
using ATMBankWebAPI.Services;

namespace ATMBankWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private readonly ICardService _service;
        private readonly IMapper _mapper;


        public CardsController(ICardService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        //GET: api/Cards
        [HttpGet]
        [EnableCors("SiteCorsPolicy")]
        public ActionResult<IEnumerable<string>> GetCards()
        {
            var cards = _service.GetAll();
            return Ok(cards.Select(c => c.Number));
        }

        // GET: api/Cards/{cardNumber}
        [HttpGet("{cardNumber}")]
        [EnableCors("SiteCorsPolicy")]
        public ActionResult<CardModel> GetCard([FromHeader(Name = "Authorize")] string pin, string cardNumber)
        {  
            Card card = _service.GetBankCard(cardNumber, pin); 
            return Ok(_mapper.Map<CardModel>(card));
        }


        // GET: api/Cards/{cardNumber}/transactions
        [EnableCors("SiteCorsPolicy")]
        [HttpGet("{cardNumber}/transactions")]
        public ActionResult<IEnumerable<TransactionModel>>
            GetCardTransactions([FromHeader(Name = "Authorize")] string pin, string cardNumber)
        {
            var transactions = _service.GetAllCardTransactions(cardNumber, pin);
            return Ok(_mapper.Map<IEnumerable<BankTransaction>, IEnumerable<TransactionModel>>(transactions));
        } 

    }
}
