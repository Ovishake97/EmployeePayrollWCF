using Common.Contacts;
using RepositoryLayer.Interface;
using RepositoryLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public class EmployeeBusiness: IEmployeeBusiness
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeBusiness()
        {
            employeeRepository = new EmployeeRepository();
        }
        ///UC1
        ///Retrieving the employee list with the help of the method written in the repository section
        ///and returning the list of employees
        public IList<EmployeeContract> GetAllEmployee()
        {
            IList<EmployeeContract> employeeContracts = employeeRepository.GetAllEmployee();
            if (employeeContracts != null)
            {
                return employeeContracts;
            }
            else
            {
                return new List<EmployeeContract>();
            }
        }
        /// UC2
        /// Retrieving an employee with the help of the id and
        /// filling up the EmployeeContract object with the obtained data
        public EmployeeContract GetById(int empId)
        {
            EmployeeContract employeeContract = null;
            Emp_Payroll Employee = employeeRepository.GetById(empId);
            if (Employee != null)
            {
                employeeContract = new EmployeeContract()
                {
                    Name = Employee.name,
                    Email = Employee.email,
                    Salary = (int)Employee.salary,
                    Id = Employee.id
                };
                return employeeContract;
            }
            else
            {
                return employeeContract;
            }
        }
        /// UC3
        /// Retrieving the added employee with the help of the method written in repository
        /// and filling up the EmployeeContract object with it
        public EmployeeContract AddEmployee(EmployeeContract employeeContract)
        {
            try
            {
                EmployeeContract empDetails = employeeRepository.AddEmployee(employeeContract);
                if (empDetails.Id > 0)
                {
                    return empDetails;
                }
                else
                {
                    throw new Exception("Employee not able to add.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        /// UC4
        /// Similar logic as UC3
        public List<EmployeeContract> AddMultipleEmployees(List<EmployeeContract> employeeContract)
        {
            try
            {

                List<EmployeeContract> empDetails = employeeRepository.AddMultipleEmployees(employeeContract);
                return empDetails;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        /// UC5
        /// Checking whether SaveChanges() is working or not 
        /// and returning a desired set of message
        public string UpdateEmployee(EmployeeContract employeeContract, int EmpId)
        {
            if (employeeRepository.UpdateEmployee(employeeContract, EmpId) == 1)
            {
                return "Employee updated successfully";
            }
            else
            {
                return "Employee not updated";
            }
        }
        /// UC6
        /// Checking whether SaveChanges() is working or not 
        /// and returning a desired set of message
        public string DeleteEmployee(int empId)
        {
            if (employeeRepository.DeleteEmployee(empId) == 1)
            {
                return "Employee deleted successfuly";
            }
            else
            {
                return "Employee does not exists.";
            }
        }
    }
}
