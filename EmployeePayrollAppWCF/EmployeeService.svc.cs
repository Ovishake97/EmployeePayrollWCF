using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using BusinessLayer.Interface;
using Common;
using Common.Contacts;

namespace EmployeePayrollAppWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EmployeeService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select EmployeeService.svc or EmployeeService.svc.cs at the Solution Explorer and start debugging.
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeBusiness employeeBusiness;
        public EmployeeService()
        {
            employeeBusiness = new EmployeeBusiness();
        }
        public List<EmployeeContract> employees;

        /// UC1- Retrieving the employees 
        public IList<EmployeeContract> GetAllEmployee()
        {
            return employeeBusiness.GetAllEmployee();
        }

        public void DoWork()
        {
            throw new NotImplementedException();
        }
    }
}
