using ASPCoreWebAPI.Data;
using ASPCoreWebAPI.Models;
using ASPCoreWebAPI.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

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

        [HttpPost]
        public IActionResult CreateEmployee(EmployeeDTO employeeDto)

        {
            var employee = new Employee
            {
                Name = employeeDto.Name,
                Email = employeeDto.Email,
                Phone = employeeDto.Phone,
                Salary = employeeDto.Salary
            };
            dbContext.Employees.Add(employee);
            dbContext.SaveChanges();
            return Ok(employee);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetEmployeeById(Guid id)
        {
            var employeeid = dbContext.Employees.Find(id);
            if (employeeid == null)
            {
                return NotFound();

            }
            return Ok(employeeid);
        }
        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateEmployeeById(Guid id,UpdateEmployeeDto updateEmployeeDto)
        {
            var employeeid = dbContext.Employees.Find(id);
            if (employeeid == null)
            {
                return NotFound();

            }
            employeeid.Name = updateEmployeeDto.Name;
            employeeid.Email = updateEmployeeDto.Email;
            employeeid.Phone = updateEmployeeDto.Phone;
            employeeid.Salary = updateEmployeeDto.Salary;
            dbContext.SaveChanges();
            return Ok(employeeid);
        }
    }
}
