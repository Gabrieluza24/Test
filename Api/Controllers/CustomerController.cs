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

        public CustomerController(IAddCustomerService addCustomer)
        {
            _addCustomer = addCustomer;
        }

        // GET: CustomerController
        [HttpGet(Name = "GetCustomer")]
        public ActionResult Index()
        {
            return Ok();
        }

        // GET: CustomerController/Details/5
        [HttpGet]
        [Route("{text}")]
        public ActionResult Details(int id)
        {
            return Ok();
        }

        // POST: CustomerController/Create
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddCustomerDto request)
        {
            try
            {
                AddCustomerResponseDto response = await _addCustomer.Create(request);
                return new OkObjectResult(response);
            }
            catch
            {
                return new BadRequestObjectResult("Error");
            }
        
        }

        // PUT: CustomerController/Edit/5
        [HttpPut]
        public ActionResult Edit(int id, IFormCollection collection)
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
