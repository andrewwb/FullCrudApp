using Repositories.Data;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repositories.Infrastructure
{
    public class EmployeeRepository : GenericRepository<Employee>
    {
        public EmployeeRepository(ApplicationDbContext db) : base(db)
        {
        }

        public Employee Find(int id) {
            return (from e in _db.Employees where e.Id == id select e).FirstOrDefault();
        }

        public void Update(Employee emp) {
            var orig = Find(emp.Id);
            orig.FirstName = emp.FirstName;
            orig.LastName = emp.LastName;
            orig.Email = emp.Email;
            orig.SSN = emp.SSN;
            orig.HourlyWage = emp.HourlyWage;
            orig.Benefits = emp.Benefits;
        }

    }
}
