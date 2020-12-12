using Common.Contacts;
using RepositoryLayer.Interface;
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
    }
}
