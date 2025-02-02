﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Context;
using DAL.Mapper;
using DTO.Models;
using DAL.Models;

namespace DAL.Repository
{
    public static class TaskManagerRepository
    {
        public static TaskManagerDTO GetTaskManager(int id)
        {
            using (var context = new SagTidRegisterContext())
            {
                return TaskManagerMapper.Map(context.TaskManagers.Find(id));
            }
        }

        public static List<TaskManagerDTO> GetAllTaskManagers()
        {
            using (var context = new SagTidRegisterContext())
            {
                var retur = context.TaskManagers.ToList();
                return TaskManagerMapper.Map(retur);
            }
        }

        public static List<TaskManagerDTO> GetAllTaskManagersByDepartment(int id)
        {
            using (var context = new SagTidRegisterContext())
            {
                var retur = context.TaskManagers.Where(t => t.DepartmentId == id).ToList();
                return TaskManagerMapper.Map(retur);
            }
        }

        public static void AddTaskManager(TaskManagerDTO taskManager)
        {
            using (var context = new SagTidRegisterContext())
            {
                context.TaskManagers.Add(TaskManagerMapper.Map(taskManager));
                context.SaveChanges();
            }
        }

        public static void EditTaskManager(TaskManagerDTO taskManager)
        {
            using (var context = new SagTidRegisterContext())
            {
                var dataTaskManager = context.TaskManagers.Find(taskManager.Id);
                TaskManagerMapper.Update(taskManager, dataTaskManager);
                context.SaveChanges();
            }
        }

    }
}
