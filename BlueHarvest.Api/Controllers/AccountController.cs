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
    [Route("api/Customers/{customerId}/Accounts")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;
        public AccountController(IAccountService accountService, IMapper mapper)
        {
            this._accountService = accountService;
            this._mapper = mapper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="saveAccountResource"></param>
        /// <returns></returns>
        [HttpPost("")]
        public async Task<ActionResult<AccountResource>> CreateAccount(Guid customerId, [FromBody] SaveAccountResource saveAccountResource)
        {
            var validator = new SaveAccountResourceValidator();
            var validationResult = await validator.ValidateAsync(saveAccountResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var accountToCreate = _mapper.Map<SaveAccountResource, Account>(saveAccountResource);
            accountToCreate.CustomerId = customerId;
            var newAccount = await _accountService.CreateAccount(accountToCreate);

            var accountResource = _mapper.Map<Account, AccountResource>(newAccount);

            return Ok(accountResource);
        }
    }
}
