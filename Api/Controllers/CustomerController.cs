using Api.Dtos.Customers;
using Api.Services.Interface;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IAddCustomerService _addCustomer;
        private readonly IGetCustomersService _getCustomers;
        private readonly IUpdateCustomerService _updateCustomer;
        private readonly IDeleteCustomerService _deleteCustomer;
        private readonly IValidator<AddCustomerDto> _addCustomerValidator;
        private readonly IValidator<UpdateCustomerDto> _updateCustomerValidator;

        public CustomerController(
            IAddCustomerService addCustomer,
            IGetCustomersService getCustomers,
            IUpdateCustomerService updateCustomer,
            IDeleteCustomerService deleteCustomer,
            IValidator<AddCustomerDto> addCustomerValidator,
            IValidator<UpdateCustomerDto> updateCustomerValidator
        )
        {
            _addCustomer = addCustomer;
            _getCustomers = getCustomers;
            _updateCustomer = updateCustomer;
            _deleteCustomer = deleteCustomer;
            _addCustomerValidator = addCustomerValidator;
            _updateCustomerValidator = updateCustomerValidator;
        }

        /**Get All Customers Controller*/
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try { 
                List<CustomerDto> response = await _getCustomers.GetAll();
                return new OkObjectResult(response);
            }
            catch(Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
            
        }

        /**Create Customer Controller*/
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddCustomerDto request)
        {
            try
            {
                var validateModel = _addCustomerValidator.Validate(request);
                if (!validateModel.IsValid) throw new Exception(validateModel.Errors.First().ErrorMessage);

                CustomerDto response = await _addCustomer.Create(request);
                return new OkObjectResult(response);
            }
            catch(Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        
        }

        /**Update Customer Controller*/
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Edit(int id, [FromBody] UpdateCustomerDto request)
        {
            try
            {
                var validateModel = _updateCustomerValidator.Validate(request);
                if (!validateModel.IsValid) throw new Exception(validateModel.Errors.First().ErrorMessage);

                CustomerDto response = await _updateCustomer.update(id,request);
                return new OkObjectResult(response);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }

        }

        /**Delete Customer Controller*/
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                CustomerDto response = await _deleteCustomer.remove(id);
                return new OkObjectResult(response);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
    }
}
