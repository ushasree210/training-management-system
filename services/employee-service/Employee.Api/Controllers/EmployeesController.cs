using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetEmployees()
        {
            var employees = new[]
            {
                new { Id = 5, Name = "Alice", Department = "Engineering" },
                new { Id = 3, Name = "Bob", Department = "HR" },
                new { Id = 2, Name = "Bob", Department = "doctor" }

                //wnqkw

            };
           
            return Ok(employees);
        }

    }
}
