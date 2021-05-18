using AutoMapper;
using BlueHarvest.Api.Resources;
using BlueHarvest.Api.Validators;
using BlueHarvest.Core.Models;
using BlueHarvest.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueHarvest.Api.Controllers
{
    [Route("api/Customers/{customerId}/Accounts/{accountId}/Transactions")]
    [ApiController]
    public class TransactionController : Controller
    {
        private readonly ITransactionService _transactionService;
        private readonly IMapper _mapper;
        public TransactionController(ITransactionService transactionService, IMapper mapper)
        {
            this._transactionService = transactionService;
            this._mapper = mapper;
        }

        [HttpPost("")]
        public async Task<ActionResult<TransactionResource>> CreateTransaction(Guid customerId, Guid accountId, [FromBody] SaveTransactionResource saveTransactionResource)
        {
            var validator = new SaveTransactionResourceValidator();
            var validationResult = await validator.ValidateAsync(saveTransactionResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var transactionToCreate = _mapper.Map<SaveTransactionResource, Transaction>(saveTransactionResource);
            transactionToCreate.AccountId = accountId;

            var newTransaction = await _transactionService.CreateTransaction(transactionToCreate);

            var transactionResource = _mapper.Map<Transaction, TransactionResource>(newTransaction);

            return Ok(transactionResource);
        }
    }
}
