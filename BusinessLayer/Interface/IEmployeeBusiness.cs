﻿using Common.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface IEmployeeBusiness
    {
        IList<EmployeeContract> GetAllEmployee();
        EmployeeContract GetById(int empId);
        EmployeeContract AddEmployee(EmployeeContract employeeContract);
    }
}
