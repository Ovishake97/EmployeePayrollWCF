﻿using Common.Contacts;
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
    }
}
