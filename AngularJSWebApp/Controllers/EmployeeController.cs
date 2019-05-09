using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AngularJSWebApp.DAL;

namespace AngularJSWebApp.Controllers
{
    public class EmployeeController : ApiController
    {
        private EmployeeDBEntities1 _employeeDBEntities;

        public EmployeeController()
        {
            if (_employeeDBEntities == null)
            {
                EmployeeDBEntities1 employeeDBEntities = new EmployeeDBEntities1();
                _employeeDBEntities = employeeDBEntities;
            }
        }

        [HttpGet]
        [Route("api/Employees")]
        public IEnumerable<Employee> Get()
        {
            return _employeeDBEntities.Employees.ToList();
           //return Ok(new { results = employees });
        }

        [HttpGet]
        public Employee Get(int id)
        {
            return _employeeDBEntities.Employees.Select(a => a).Where(a => a.Id == id).SingleOrDefault();
        }

        [HttpPost]
        public void CreateEmployee(Employee employee)
        {
            if(employee != null)
            {
                _employeeDBEntities.Employees.Add(employee);
                _employeeDBEntities.SaveChanges();
            }
        }
    }
}
