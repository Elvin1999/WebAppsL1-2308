using System.Collections;
using System.Collections.Generic;
using WebApplication1.Entities;

namespace WebApplication1.Models
{
    public class EmployeeListViewModel
    {
        public IEnumerable<Employee> Employees { get; set; }
        public IEnumerable<string> Cities { get; set; }
    }
}
