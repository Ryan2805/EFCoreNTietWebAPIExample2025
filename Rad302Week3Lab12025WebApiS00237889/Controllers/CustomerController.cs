using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RAD302Week3Lab12025CLS00237889;
using Tracker.WebAPIClient;

namespace Rad302Week3Lab12025WebApiS00237889.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private readonly ICustomer<Customer> _repository;

        public CustomerController(ICustomer<Customer> repository)
        {
            _repository = repository;
        }
        // Must decorate for swagger
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            ActivityAPIClient.Track(StudentID: "S00237889", StudentName: "Ryan Daly",
            activityName: "Rad302 Week 3 Lab 1", Task: "Testing Basic Controller Call");
            return _repository.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Customer> GetCustomerByID(int id)
        {
            ActivityAPIClient.Track(StudentID: "S00237889", StudentName: "Ryan Daly",
            activityName: "Rad302 Week 3 Lab 1", Task: "Testing Get Customer By ID Call");
            var customer = _repository.Get(id);

            if (customer == null)
            {
                return NotFound(); 
            }

            return Ok(customer); 
        }

        [HttpGet("CheckCustomerCredit/{customerId}/{amount}")]
        public ActionResult<bool> CheckCustomerCredit(int customerId, float amount)
        {
            ActivityAPIClient.Track(StudentID: "S00237889", StudentName: "Ryan Daly",
            activityName: "Rad302 Week 3 Lab 1", Task: "Testing Customer Credit rating call");
            var isCreditSufficient = _repository.CheckCredit(customerId, amount);

            
            return Ok(isCreditSufficient);
        }

    }
}
