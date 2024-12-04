using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tid__og_sagsregistreringssystem.Models;

namespace Tid__og_sagsregistreringssystem.Controllers
{
    public class EmployeeController : Controller
    {
        private List<Employee> employees = new List<Employee>();
        private List<Department> departments = new List<Department>();

        public void testData()
        {

            
           

            
            var company = new Company("sejt company ja");
            //departments.Add(new Department("undersøgelse", company));

        }

        // GET: EmployeeController
        public ActionResult Index()
        {
            testData(); // testing was up 

            ViewBag.Employees = employees;
            ViewBag.Departments = departments;

            return View("Employee");
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [Route("employee/create")]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                // gem i database
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }
    }
}
