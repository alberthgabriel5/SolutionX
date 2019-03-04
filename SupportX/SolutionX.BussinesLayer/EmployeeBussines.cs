using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolutionX.DataAccess;
using SolutionX.DomainEntities;

namespace SolutionX.BussinesLayer
{
    public class EmployeeBussines
    {

        EmployeeDataAccess employeeData = new EmployeeDataAccess();

        public Employee VerifyUser(Employee employee)
        {
          return employeeData.VerifyUser(employee);

        }

        public void AssignRole(Role role, Employee employee)
        {
            employeeData.AssignRole(role,employee);

        }
        public List<Employee> ListCoordinator()
        {
            return employeeData.ListCoordinator();
        }

        public List<Employee> ListEmployee()
        {
            return employeeData.ListEmployee();
        }

    }
        
}
