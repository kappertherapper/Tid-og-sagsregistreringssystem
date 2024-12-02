using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tid__og_sagsregistreringssystem.Models
{
    public class Department
    {
        private string name { get; set; }
        private int number { get; set; }
        private Company company { get; set; }
        private List<TaskManager> tasks { get; set; }

    }
}
