using CarBookingManager.API.Dtos.Requests;
using CarBookingManager.API.Dtos.Responses;
using CarBookingManager.API.Services.CustomerService;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace CarBookingManager.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IValidator<CustomerRequest> _customerValidator;

        public CustomerController(ICustomerService customerService, IValidator<CustomerRequest> customerValidator)
        {
            _customerService = customerService;
            _customerValidator = customerValidator;
        }

        [HttpPost(nameof(Add))]
        public async Task<ActionResult> Add(CustomerRequest customerRequest)
        {
            var result = _customerValidator.Validate(customerRequest);
            if (result.IsValid)
            {
                await _customerService.AddAsync(customerRequest);
                return Ok();
            }
            return BadRequest();

        }

        [HttpDelete(nameof(Delete))]
        public async Task<ActionResult> Delete(string personalNo)
        {

            await _customerService.DeleteAsync(personalNo);
            return Ok();
        }

        [HttpPatch(nameof(Update))]
        public async Task<ActionResult> Update(CustomerRequest customerRequest)
        {
            var result = _customerValidator.Validate(customerRequest);
            if (result.IsValid)
            {
                await _customerService.UpdateAsync(customerRequest);
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet(nameof(GetAll))]
        public async Task<ActionResult<IEnumerable<CustomerResponse>>> GetAll()
        {

            return Ok(await _customerService.GetAllAsync());

        }
    }
}
