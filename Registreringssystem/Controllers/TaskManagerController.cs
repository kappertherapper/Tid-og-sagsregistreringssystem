using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;
using Newtonsoft.Json;
using Registreringssystem.Models;

namespace Tid__og_sagsregistreringssystem.Controllers
{
    public class TaskManagerController : Controller
    {
        public List<Department> departments = new List<Department>();
        public List<Employee> employees = new List<Employee>();
        public List<TaskManager> tasks = new List<TaskManager>();

        //test data
        private void InitializeTestData()
        {
            // Creating company
            var company = new Company("sejt company ja");

            // Creating departments
            var department1 = new Department("undersøgelse", company, 1);
            var department2 = new Department("biologisk", company, 2);
            var department3 = new Department("kateofask", company, 3);

            // Creating employees
            var employee1 = new Employee("Anders", "110795-5566");
            var employee2 = new Employee("Noller", "160288-2776");
            var employee3 = new Employee("Flemming", "110795-5786");

            // Creating tasks
            var task1 = new TaskManager("help", 1, "bare gøre det");
            var task2 = new TaskManager("hæfghlp", 2, "ja gsdføre det");
            var task3 = new TaskManager("dfg",3, "ja gøre det");
            var task4 = new TaskManager("hældfgp", 4, "ja gøre det");
            var task5= new TaskManager("hæfghlp", 5, "ja gøre det");

            // Assigning departments
            employee1.AssignDepartment(department1);
            employee2.AssignDepartment(department2);
            employee3.AssignDepartment(department3);

            employees.AddRange(new[] { employee1, employee2, employee3 });
            departments.AddRange(new[] { department1, department2, department3 });

            //Assigning tasks
            task1.AssignDepartment(department1);
            task2.AssignDepartment(department2);
            task3.AssignDepartment(department3);
            task4.AssignDepartment(department1);
            task5.AssignDepartment(department2);

            tasks.AddRange(new[] { task1, task2, task3, task4, task5 });
        }

        public ActionResult Index()
        {
            InitializeTestData(); //test
            ViewBag.Departments = departments;
            ViewBag.Tasks = tasks;
            return View("TaskManagerOverView");
        }

        
        [HttpGet]
        public JsonResult GetEmployeesByDepartment(int departmentNumber)
        {
            InitializeTestData();

            var filteredEmployees = employees
                .Where(e => e.Department != null && e.Department.Number == departmentNumber)
                .Select(e => new { e.Name, e.Cpr })
                .ToList();

            Debug.WriteLine(JsonConvert.SerializeObject(filteredEmployees));

            return Json(filteredEmployees);
        }
        [HttpGet]
        public JsonResult GetTasksByDepartment(int departmentNumber)
        {
            InitializeTestData();

            var filteredTasks = tasks
                .Where(t => t.Department != null && t.Department.Number == departmentNumber)
                .Select(t => new { t.Title, t.TaskNumber })
                .ToList();

            return Json(filteredTasks);
        }

        // GET: TaskManagerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TaskManagerController/Create
        public ActionResult CreateTimeStamp(TimeStamp timeStamp)
        {
            if (timeStamp.Task == null)
            {
                Console.WriteLine("Task er null");
            }

            if (timeStamp.Employee == null)
            {
                Console.WriteLine("medarbejder er null");
            }

            if (timeStamp.StartTime >= timeStamp.EndTime)
            {
                Console.WriteLine("Sluttidspunkt skal være efter start");
            }

            if (timeStamp.Task.Department != timeStamp.Employee.Department)
            {
                Console.Write("Medarbejder og task er ikke i samme afdeling");
            }

            

            return RedirectToAction("Index");
        }

        // GET: TaskManagerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }


        // GET: TaskManagerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }
    }
}
