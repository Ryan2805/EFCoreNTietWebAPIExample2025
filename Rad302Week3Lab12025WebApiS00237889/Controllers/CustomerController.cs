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

    }
}
