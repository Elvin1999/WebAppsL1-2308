using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Entities;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class EmployeeController : Controller
    {
        static List<Employee> employees = new List<Employee>
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
        public IActionResult Index()
        {
            var vm = new EmployeeListViewModel
            {
                Employees = employees
            };
            return View(vm);
        }

        public IActionResult Delete(int id)
        {
            var item = employees.FirstOrDefault(e => e.Id == id);
            if (item != null)
            {
                employees.Remove(item);
                TempData["Message"] = $"{item.Firstname} employee deleted successfully";
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Add()
        {
            var vm = new EmployeeAddViewModel
            {
                Employee = new Employee(),
                Cities=new List<SelectListItem>
                {
                    new SelectListItem{Text="Baku",Value="10"},
                    new SelectListItem{Text="Khirdalan",Value="1"},
                    new SelectListItem{Text="Sumqayit",Value="50"}
                }
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult Add(EmployeeAddViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                viewModel.Employee.Id = (new Random()).Next(1, 10000);
                employees.Add(viewModel.Employee);
                return RedirectToAction("Index");
            }
            viewModel.Cities = new List<SelectListItem>
                {
                    new SelectListItem{Text="Baku",Value="10"},
                    new SelectListItem{Text="Khirdalan",Value="1"},
                    new SelectListItem{Text="Sumqayit",Value="50"}
                };
            return View(viewModel);
        }
    }
}
