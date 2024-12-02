using System;

namespace Tid__og_sagsregistreringssystem.Models
{
    public class TimeStamp
    {
        private DateTime StartTime { get; set; } 
        private DateTime EndTime { get; set; }
        private TaskManager Task { get; set; }
        private Employee Employee { get; set; }
    }
}
