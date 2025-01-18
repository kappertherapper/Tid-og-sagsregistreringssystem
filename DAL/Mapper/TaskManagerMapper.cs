using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Models;
using DAL.Models;

namespace DAL.Mapper
{
    public  class TaskManagerMapper
    {
        public static TaskManagerDTO Map(TaskManager taskManager)
        {
            var DTOtaskManager = new TaskManagerDTO();
            if (taskManager != null)
            {
                DTOtaskManager.Id = taskManager.Id;
                DTOtaskManager.Title = taskManager.Title;
                DTOtaskManager.TaskNumber = taskManager.TaskNumber;
                DTOtaskManager.Description = taskManager.Description;
                DTOtaskManager.DepartmentId = taskManager.DepartmentId;

                return DTOtaskManager;
            }
            else return null;
        }

        public static TaskManager Map(TaskManagerDTO taskManagerDTO)
        {
            var DALtaskManager = new TaskManager();
            if (taskManagerDTO != null)
            {
                DALtaskManager.Id = taskManagerDTO.Id;
                DALtaskManager.Title = taskManagerDTO.Title;
                DALtaskManager.TaskNumber = taskManagerDTO.TaskNumber;
                DALtaskManager.Description = taskManagerDTO.Description;
                DALtaskManager.DepartmentId = taskManagerDTO.DepartmentId;

                return DALtaskManager;
            }
            else return null;
        }

        public static List<TaskManagerDTO> Map(List<TaskManager> taskManagers)
        {
            return taskManagers.Select(TaskManagerMapper.Map).ToList();
        }

        public static List<TaskManager> Map(List<TaskManagerDTO> taskManagerDTOs)
        {
            return taskManagerDTOs.Select(TaskManagerMapper.Map).ToList();
        }

        internal static void Update(TaskManagerDTO taskManager, TaskManager data)
        {
            if (taskManager != null)
            {
                data.Id = taskManager.Id;
                data.Title = taskManager.Title;
                data.Description = taskManager.Description;
                data.DepartmentId = taskManager.DepartmentId;
                data.TaskNumber = taskManager.TaskNumber;
            }
            else
                data = null;
        }
    }
}
