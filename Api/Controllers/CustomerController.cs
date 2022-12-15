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

        public CustomerController(
            IAddCustomerService addCustomer,
            IGetCustomersService getCustomers,
            IUpdateCustomerService updateCustomer
        )
        {
            _addCustomer = addCustomer;
            _getCustomers = getCustomers;
            _updateCustomer = updateCustomer;
        }

        // GET: CustomerController
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

        // POST: CustomerController/Create
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

        // PUT: CustomerController/Edit/5
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

        // DELETE: CustomerController/Delete/5
        [HttpDelete]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return Ok();
            }
        }
    }
}
