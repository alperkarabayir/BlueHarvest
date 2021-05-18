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
    [Route("api/Customers")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;
        public CustomerController(ICustomerService customerService, IMapper mapper)
        {
            this._customerService = customerService;
            this._mapper = mapper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<CustomerResource>>> GetAllCustomers()
        {
            var customers = await _customerService.GetAllCustomers();
            var customersResources = _mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerResource>>(customers);
            return Ok(customersResources);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        [HttpGet("{customerId}")]
        public async Task<ActionResult<CustomerResource>> GetCustomerById(Guid customerId)
        {
            try
            {
                var customer = await _customerService.GetCustomerById(customerId);
                if (customer != null)
                {
                    var customerResource = _mapper.Map<Customer, CustomerResource>(customer);

                    return Ok(customerResource);
                }
                return NotFound();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("")]
        public async Task<ActionResult<CustomerResource>> CreateCustomer([FromBody] SaveCustomerResource saveCustomerResource)
        {
            var validator = new SaveCustomerResourceValidator();
            var validationResult = await validator.ValidateAsync(saveCustomerResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var customerToCreate = _mapper.Map<SaveCustomerResource, Customer>(saveCustomerResource);
            var newCustomer = await _customerService.CreateCustomer(customerToCreate);

            var customerResource = _mapper.Map<Customer, CustomerResource>(newCustomer);

            return Ok(customerResource);
        }
    }
}
