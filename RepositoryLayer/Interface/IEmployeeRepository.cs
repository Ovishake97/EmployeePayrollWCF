using Common.Contacts;
using RepositoryLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interface
{
    public interface IEmployeeRepository
    {
        IList<EmployeeContract> GetAllEmployee();
        Emp_Payroll GetById(int empId);
        EmployeeContract AddEmployee(EmployeeContract employeeContract);
    }
}
