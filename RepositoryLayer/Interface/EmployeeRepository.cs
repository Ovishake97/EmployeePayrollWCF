using Common.Contacts;
using RepositoryLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interface
{
    public class EmployeeRepository:IEmployeeRepository
    {
        employee_contact_wcfEntities1 employeeManagementEntitiesObj;
        public EmployeeRepository()
        {
            employeeManagementEntitiesObj = new employee_contact_wcfEntities1();
        }

        public IList<EmployeeContract> GetAllEmployee()
        {
            var query = (from a in employeeManagementEntitiesObj.Emp_Payroll select a).Distinct();
            List<EmployeeContract> employeeData = new List<EmployeeContract>();

            query.ToList().ForEach(x =>
            {
                employeeData.Add(new EmployeeContract
                {
                    Id = x.id,
                    Name = x.name,
                    Email = x.email,
                    Salary = (int)x.salary
                });
            });

            return employeeData;
        }
        
    }
}
