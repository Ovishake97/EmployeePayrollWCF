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
        public Emp_Payroll GetById(int empId)
        {
            var employee = employeeManagementEntitiesObj.Emp_Payroll
                .Find(empId);

            return employee;
        }
        public EmployeeContract AddEmployee(EmployeeContract employeeContract)
        {
            Emp_Payroll employee = new Emp_Payroll()
            {
                name = employeeContract.Name,
                email = employeeContract.Email,
                salary = employeeContract.Salary
            };
            employeeManagementEntitiesObj.Emp_Payroll.Add(employee);
            employeeManagementEntitiesObj.SaveChanges();
            employeeContract.Id = employee.id;
            return employeeContract;

        }
        public List<EmployeeContract> AddMultipleEmployees(List<EmployeeContract> employeeContract)
        {
            foreach (EmployeeContract emp in employeeContract)
            {
                Emp_Payroll employee = new Emp_Payroll()
                {
                    name = emp.Name,
                    email = emp.Email,
                    salary = emp.Salary
                };
                employeeManagementEntitiesObj.Emp_Payroll.Add(employee);
                employeeManagementEntitiesObj.SaveChanges();
                emp.Id = employee.id;
            }

            return employeeContract;
        }
        public int UpdateEmployee(EmployeeContract employeeContract, int EmpId)
        {
            Emp_Payroll employee = employeeManagementEntitiesObj
                .Emp_Payroll.Find(EmpId);
            if (employee != null)
            {
                employee.email = employeeContract.Email;
                employee.name = employeeContract.Name;
                employee.salary = employeeContract.Salary;
                return employeeManagementEntitiesObj.SaveChanges();
            }
            else
            {
                throw new Exception("Employee do not exists");
            }
        }
    }
}
