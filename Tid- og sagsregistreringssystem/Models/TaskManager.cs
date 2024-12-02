using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tid__og_sagsregistreringssystem.Models
{
    public class TaskManager
    {
        private string Title { get; set; }
        private int TaskNumber { get; set; }
        private string Description { get; set; }
        private Department Department { get; set; }
        private Dictionary<TimeStamp, Employee> TimeStamps { get; set; }

    }
}
