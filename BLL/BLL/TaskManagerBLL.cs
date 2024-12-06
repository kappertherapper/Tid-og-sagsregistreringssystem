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

        public List<TaskManagerDTO> GetAllTaskManagers()
        {
            return TaskManagerRepository.GetAllTaskManagers();
        }

        public int AddTaskManager(TaskManagerDTO taskManager)
        {
            if (taskManager == null) throw new ArgumentNullException();
            return TaskManagerRepository.AddTaskManager(taskManager);
        }

        public void EditTaskManager(TaskManagerDTO taskManager)
        {
            if (taskManager == null) throw new ArgumentNullException();
            TaskManagerRepository.EditTaskManager(taskManager);
        }
    }
}
