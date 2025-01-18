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
        public DateTime startTime { get; }
        public DateTime endTime  { get; }

        public List<SelectListItem> Departments { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Tasks { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Employees { get; set; } = new List<SelectListItem>();
    }
    
    public class TaskManagerController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var departments = DepartmentBLL.GetAllDepartments();
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
            var departments = DepartmentBLL.GetAllDepartments();

            model.Departments = departments.Select(d => new SelectListItem
            {
                Value = d.Id.ToString(),
                Text = d.Name
            }).ToList();
            
            var tasks = TaskManagerBLL.GetAllTaskManagersByDepartment(model.SelectedDepartmentID);
            var employees = EmployeeBLL.GetAllEmployeesByDepartment(model.SelectedDepartmentID);

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
            if (!ModelState.IsValid) return View(model);

            if (model.SelectedTaskID == null) return RedirectToAction("Index");
            if (model.SelectedEmployeesID == null) return RedirectToAction("Index");
            
            var timestamp = new TimeStampDTO(
                model.startTime,
                model.endTime,
                (int)model.SelectedTaskID,
                (int)model.SelectedEmployeesID);

            TimeStampBLL.AddTimeStamp(timestamp);
            return RedirectToAction("Index");
        }
    }
}
