using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tid__og_sagsregistreringssystem.Models
{
    public class TaskManager
    {
        private string title { get; set; }
        private int taskNumber { get; set; }
        private string description { get; set; }
        private Department department { get; set; }
        private Dictionary<TimeStamp, Employee> timeStamps { get; set; }

    }
}
