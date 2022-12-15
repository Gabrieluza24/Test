using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        public CustomerController() { }

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
        public ActionResult Create(IFormCollection collection)
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
