﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Repositories.Data;
using Repositories.Models;
using Repositories.Services;
using Repositories.Infrastructure;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Repositories.Controllers
{
    [Route("api/[controller]")]
    public class EmployeesController : Controller
    {
        private EmployeeService _service;
        public EmployeesController(EmployeeService service) {
            _service = service;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<MinEmployee> Get()
        {
            return _service.GetMinifiedEmployees();
        }

        [HttpGet("admin")]
        public IEnumerable<Employee> GetEmployees() {
            return _service.GetEmployees();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            return _service.FindEmployee(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Employee value)
        {
            _service.AddEmployee(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put([FromBody]Employee value)
        {
            _service.UpdateEmployee(value);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.DeleteEmployee(id);
        }
    }
}
