namespace Tid__og_sagsregistreringssystem.Models
{
    public class Employee
    {
        private static int counter = 0; // counter for initials
        private string Name {  get; set; }
        private int Initials { get; set; }
        private int Cpr { get; set; }

        public Employee(string name, int cpr)
        {
            Name = name;
            Initials = ++counter;
            Cpr = cpr;
        }

        public string GetName() => Name;
        public int GetInitials() => Initials;
        public int GetCpr() => Cpr;
    }
}
