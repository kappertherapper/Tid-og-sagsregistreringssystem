using DataAccessLayer.Repository;
using DataTransferObject.Models;
using System;

namespace BusinessLogicLayer.BLL
{
    public class EmployeeBLL
    {
        public EmployeeBLL() { }
        public EmployeeDTO GetEmployee(int id)
        {
            if (id < 0) throw new IndexOutOfRangeException();
            return EmployeeRepository.GetEmployee(id);
        }
        public int AddEmployee(EmployeeDTO employee)
        {
            //valider employee
            return EmployeeRepository.AddEmployee(employee);
        }
        public void EditEmployee(EmployeeDTO employee)
        {
            EmployeeRepository.EditEmployee(employee);
        }
    }
}
