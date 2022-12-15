using Api.Dtos.Customers;
using Api.Services.Interface;
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

        public CustomerController(
            IAddCustomerService addCustomer,
            IGetCustomersService getCustomers,
            IUpdateCustomerService updateCustomer,
            IDeleteCustomerService deleteCustomer
        )
        {
            _addCustomer = addCustomer;
            _getCustomers = getCustomers;
            _updateCustomer = updateCustomer;
            _deleteCustomer = deleteCustomer;
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
