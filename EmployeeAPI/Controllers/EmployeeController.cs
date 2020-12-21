using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Employee.Application;

namespace EmployeeAPI.Controllers
{
    [RoutePrefix("EmployeeDetails")]
    public class EmployeeController : ApiController
    {
        private readonly IEmployeeApp _employeeApp;

        public EmployeeController(IEmployeeApp employeeApp)
        {
            _employeeApp = employeeApp;
        }
        // GET api/<controller>/5

        [Route("GetAllEmployee")]
        [HttpGet]
        public List<Employee.Model.Employee> GetAllEmployee()
        {
           var employees= _employeeApp.GetEmployeeDetail();
            return employees;
        }

        // POST api/<controller>
        [Route("CreateEmployee")]
        [HttpPost]
        public void CreateEmployee(Employee.Model.Employee employee)
        {
            _employeeApp.CreateEmployeeDetail(employee); 
        }

        // PUT api/<controller>/5
        [Route("UpdateEmployee/{id}")]
        [HttpPost]
        public void UpdateEmployee(int id, Employee.Model.Employee employee)
        {
            _employeeApp.UpdateEmployeeDetail(id,employee);
        }

        // DELETE api/<controller>/5
        [Route("DeleteEmployee/{id}")]
        [HttpPost]
        public void DeleteEmployee(int id)
        {
            _employeeApp.DeleteEmployeeDetail(id);
        }
    }
}