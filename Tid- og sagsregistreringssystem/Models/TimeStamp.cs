using System;

namespace Tid__og_sagsregistreringssystem.Models
{
    public class TimeStamp
    {
        private DateTime startTime { get; set; } 
        private DateTime endTime { get; set; }
        private TaskManager task { get; set; }
        private Employee employee { get; set; }
    }
}
