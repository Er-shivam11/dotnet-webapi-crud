using ASPCoreWebAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPCoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        //connect constructor using db connection 
        private readonly ApplicationDbContext dbContext;
        public EmployeesController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;

        }


        [HttpGet]
        //get info about iaction 
        public IActionResult GetAllEmployees()
        {
            var allEmpployees = dbContext.Employees.ToList();
            return Ok(allEmpployees);
        }
    }
}
