using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tid__og_sagsregistreringssystem.Models;

namespace Tid__og_sagsregistreringssystem.Controllers
{
    public class TaskManagerController : Controller
    {
        private List<Department> departments = new List<Department>();
        private List<Employee> employees = new List<Employee>();

        //test data
        private void InitializeTestData()
        {
            // Creating company
            var company = new Company("sejt company ja");

            // Creating departments
            var department1 = new Department("undersøgelse", company) { Number = 1 };
            var department2 = new Department("biologisk", company) { Number = 2 };
            var department3 = new Department("kateofask", company) { Number = 3 };

            // Creating employees
            var employee1 = new Employee("Anders", "110795-5566");
            var employee2 = new Employee("Noller", "160288-2776");
            var employee3 = new Employee("Flemming", "110795-5786");

            // Assigning departments
            employee1.AssignDepartment(department1);
            employee2.AssignDepartment(department2);
            employee3.AssignDepartment(department3);

            // Adding employees
            employees.Add(employee1);
            employees.Add(employee2);
            employees.Add(employee3);

            // Adding departments
            departments.Add(department1);
            departments.Add(department2);
            departments.Add(department3);
        }

        public ActionResult Index()
        {
            InitializeTestData(); //test
            ViewBag.Departments = departments;
            return View("TaskManagerOverView");
        }

        // Action to get employees by department
        public JsonResult GetEmployeesByDepartment(int departmentNumber)
        {
            InitializeTestData();

            var filteredEmployees = employees
                .Where(e => e.Department != null && e.Department.Number == departmentNumber)
                .Select(e => new { e.Name, e.Cpr })
                .ToList();

            return Json(filteredEmployees);
        }

        // GET: TaskManagerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TaskManagerController/Create
        public ActionResult CreateTask(TaskManager task)
        {
            if (ModelState.IsValid)
            {
                // gem i database
                return RedirectToAction("Index");
            }

            return View(task);
        }

        // POST: TaskManagerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TaskManagerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TaskManagerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TaskManagerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TaskManagerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
