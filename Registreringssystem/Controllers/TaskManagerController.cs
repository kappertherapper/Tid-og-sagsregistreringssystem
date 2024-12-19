using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BLL.BLL;
using DTO.Models;

namespace Tid__og_sagsregistreringssystem.Controllers
{
    public class TimeStampViewModel
    {
        public int SelectedDepartmentID { get; set; }
        public int? SelectedTaskID { get; set; }
        public int? SelectedEmployeesID { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime  { get; set; }

        public List<SelectListItem> Departments { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Tasks { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Employees { get; set; } = new List<SelectListItem>();
    }


    public class TaskManagerController : Controller
    {
        public EmployeeBLL EbLL = new EmployeeBLL();
        public DepartmentBLL DepartBLL = new DepartmentBLL();
        public TaskManagerBLL TaskBLL = new TaskManagerBLL();
        public TimeStampBLL TimeBLL = new TimeStampBLL();

        [HttpGet]
        public ActionResult Index()
        {
            var departments = DepartBLL.GetAllDepartments();
            var model = new TimeStampViewModel
            {
               
                Departments = departments.Select(d => new SelectListItem
                {
                    Value = d.Id.ToString(),
                    Text = d.Name
                })
                .ToList(),
            };

            return View("TaskManagerOverview", model);
        }

        
        [HttpPost]
        public ActionResult Index(TimeStampViewModel model)
        {
            var departments = DepartBLL.GetAllDepartments();

            model.Departments = departments.Select(d => new SelectListItem
            {
                Value = d.Id.ToString(),
                Text = d.Name
            }).ToList();


            var tasks = TaskBLL.GetAllTaskManagersByDepartment((int)model.SelectedDepartmentID);
            var employees = EbLL.GetAllEmployeesByDepartment((int)model.SelectedDepartmentID);

            model.Tasks = tasks.Select(t => new SelectListItem
            {
                Value = t.Id.ToString(),
                Text = t.Title
            }).ToList();

            model.Employees = employees.Select(e => new SelectListItem
            {
                Value = e.Id.ToString(),
                Text = e.Name
            }).ToList();

            return View("TaskManagerOverview", model);
        }
        

        [HttpPost]
        public ActionResult CreateTimeStamp(TimeStampViewModel model)
        {
            if (ModelState.IsValid)
            {
                TimeStampDTO timestamp = new TimeStampDTO(
                    model.startTime,
                    model.endTime,
                    (int)model.SelectedTaskID,
                    (int)model.SelectedEmployeesID);

                TimeBLL.AddTimeStamp(timestamp);

                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}
