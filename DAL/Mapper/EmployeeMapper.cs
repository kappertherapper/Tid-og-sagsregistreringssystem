using DTO.Models;
using DAL.Models;

namespace DAL.Mapper
{
    public static class EmployeeMapper
    {
        public static EmployeeDTO Map(Employee employee)
        {
            EmployeeDTO DTOemployee = new EmployeeDTO();
            if (employee != null)
            {
                DTOemployee.Name = employee.Name;
                return DTOemployee;
            }
            else return null;  
        }

        public static Employee Map(EmployeeDTO employee)
        {
            Employee DALemployee = new Employee();
            if (employee != null)
            {
                DALemployee.Name = employee.Name;
                DALemployee.Cpr = "000";

                return DALemployee;
            }
            else return null;
        }

        internal static void Update(EmployeeDTO employee, Employee dataemp)
        {
            if (employee != null)
            {
                dataemp.Name = employee.Name;
            }
            else
                dataemp = null;
        }
    }
}