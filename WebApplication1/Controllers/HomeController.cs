using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Entities;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public string Index()
        {
            return "Hello from Index Action";
        }

        public IActionResult Index2()
        {
            return Ok();
        }

        public IActionResult Index3()
        {
            return BadRequest();
        }

        public IActionResult Index4()
        {
            return NotFound();
        }

        List<Employee> employees = new List<Employee>
            {
                new Employee
                {
                    Id=1,
                    Firstname="Aysel",
                    Lastname="Memmedova",
                    CityId=1
                },
                new Employee
                {
                    Id=2,
                    Firstname="Huseyn",
                    Lastname="Huseynov",
                    CityId=10
                },
                new Employee
                {
                    Id=3,
                    Firstname="Ruad",
                    Lastname="Dunyamaliyev",
                    CityId=77
                },

            };
        public IActionResult Employees()
        {

            List<string> cities = new List<string> { "Baku", "Ottawa", "Oslo" };

            var vm = new EmployeeListViewModel
            {
                Employees = employees,
                Cities = cities
            };
            // return View(employees);
            // return View(vm);
            return Json(vm);
        }

        public IActionResult Employee(int id)
        {
            var employee = employees.SingleOrDefault(e => e.Id == id);
            return Json(employee);
        }

        public IActionResult Search(string word, int id)
        {
            var wordResult = word.Trim().ToLower();
            var items = employees.Where(e => e.Id == id && (e.Firstname.ToLower().Contains(wordResult) ||
            e.Lastname.ToLower().Contains(wordResult)));

            return Json(items);
        }

        public IActionResult Test()
        {
            //return Redirect("/home/employees");
            //return RedirectToAction("employees");
            //return RedirectToAction("Employee", new { id = 1 });
            var routeValue = new RouteValueDictionary(new { action = "Employee", controller = "Home", id = 1 });
            return RedirectToRoute(routeValue);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
