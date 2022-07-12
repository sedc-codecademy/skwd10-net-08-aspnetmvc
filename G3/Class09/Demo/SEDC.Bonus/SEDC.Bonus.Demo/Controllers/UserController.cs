using Microsoft.AspNetCore.Mvc;
using SEDC.Bonus.Demo.Models;

namespace SEDC.Bonus.Demo.Controllers
{
    public class UserController : Controller
    {
        //[Route("born/{year}/{month}")]
        public IActionResult BornOnDate(int year, int month)
        {
            return new JsonResult(new { year, month });
        }

        //[HttpGet("employment/{year}/{position}")]
        public IActionResult ByEmploymentYearAndPosition(int year, string position)
        {
            return Content($"Year: {year} Position: {position} ");
        }

        //[HttpGet("employment/{year:int}")]
        public IActionResult ByEmploymentYear(int year)
        {
            return Content($"Year: {year}");
        }

        //[HttpGet("all")]
        public IActionResult Employees()
        {
            List<Employee> employees = new List<Employee>()
            {
                new Employee
                {
                    Id = 1,
                    Name = "Martin",
                    Company = "Seavus Skopje"
                },
                new Employee
                {
                    Id = 2,
                    Name = "Jovana",
                    Company = "Seavus Ljubljana"
                },
                new Employee
                {
                    Id = 3,
                    Name = "Ilija",
                    Company = "Seavus Belgrad"
                }
            };
            return View(employees);
        }

        //[HttpGet("employee/details/{id:int}")]

        public IActionResult Details(int? id)
        {
            List<Employee> employees = new List<Employee>()
            {
                new Employee
                {
                    Id = 1,
                    Name = "Martin",
                    Company = "Endava Skopje"
                },
                new Employee
                {
                    Id = 2,
                    Name = "Stefan",
                    Company = "Endava Ljubljana"
                },
                new Employee
                {
                    Id = 3,
                    Name = "Stefanija",
                    Company = "Endava Belgrad"
                }
            };

            var employee = employees.SingleOrDefault(x => x.Id == id);

            return View(employee);
        }
    }
}
