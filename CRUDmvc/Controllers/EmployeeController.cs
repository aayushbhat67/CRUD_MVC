using CRUDmvc.Data;
using CRUDmvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUDmvc.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly AppDbContext context;

        public EmployeeController(AppDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var result = context.Employees.ToList();
            return View(result);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee model)
        {
            if (ModelState.IsValid)
            {
                var emp = new Employee()
                {
                    Name = model.Name,
                    City = model.City,
                    Position = model.Position,
                    Salary = model.Salary,
                };
                context.Employees.Add(emp);
                context.SaveChanges();
                TempData["error"] = "Record Created Successfully!";
                return RedirectToAction("Index");
            }

            else
            {
                TempData["message"] = "Empty fields are not accepted";
                return View(model);
            }
        }

        public IActionResult Delete(int id)
        {
            var emp = context.Employees.SingleOrDefault(e => e.Id == id);
            context.Employees.Remove(emp);
            context.SaveChanges();
            TempData["error"] = "Record Deleted Successfully!";
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var emp = context.Employees.SingleOrDefault(e => e.Id == id);
            var result = new Employee()
            {
                Name = emp.Name,
                City = emp.City,
                Position = emp.Position,
                Salary = emp.Salary,

            };

            return View(result);
        }
        [HttpPost]
        public IActionResult Edit(Employee model)
        {
            var emp = new Employee()
            {
                Id=model.Id,
                Name = model.Name,
                City = model.City,
                Position = model.Position,
                Salary = model.Salary,
            };
            context.Employees.Update(emp);
            context.SaveChanges();
            TempData["error"] = "Record Edited Successfully!";
            return RedirectToAction("Index");
        }
    }
}
