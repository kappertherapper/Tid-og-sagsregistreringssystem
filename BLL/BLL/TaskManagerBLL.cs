using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repository;
using DTO.Models;

namespace BLL.BLL
{
    public class TaskManagerBLL
    {
        public TaskManagerBLL() { }

        public TaskManagerDTO GetTaskManager(int id)
        {
            if (id < 0) throw new IndexOutOfRangeException();
            return TaskManagerRepository.GetTaskManager(id);
        }

        public static List<TaskManagerDTO> GetAllTaskManagers()
        {
            return TaskManagerRepository.GetAllTaskManagers();
        }

        public static List<TaskManagerDTO> GetAllTaskManagersByDepartment(int id)
        {
            return TaskManagerRepository.GetAllTaskManagersByDepartment(id);
        }

        public static void AddTaskManager(TaskManagerDTO taskManager)
        {
            if (taskManager == null) throw new ArgumentNullException();
            TaskManagerRepository.AddTaskManager(taskManager);
        }

        public static void EditTaskManager(TaskManagerDTO taskManager)
        {
            if (taskManager == null) throw new ArgumentNullException();
            TaskManagerRepository.EditTaskManager(taskManager);
        }
    }
}
