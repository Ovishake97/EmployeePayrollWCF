using Common.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace EmployeePayrollAppWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IEmployeeService" in both code and config file together.
    [ServiceContract]
    public interface IEmployeeService
    {
        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/GetAllEmployee")]
        IList<EmployeeContract> GetAllEmployee();
        [OperationContract]
        [WebInvoke(Method = "GET",
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "/get/{EmpId}")]
        EmployeeContract GetById(string EmpId);
        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/Add")]
        EmployeeContract AddEmployee(EmployeeContract employeeContract);
        [OperationContract]
        [WebInvoke(Method = "POST",
          RequestFormat = WebMessageFormat.Json,
          ResponseFormat = WebMessageFormat.Json,
          UriTemplate = "/AddMultiple")]
        List<EmployeeContract> AddMultipleEmployees(List<EmployeeContract> employeeContract);
        [OperationContract]
        [WebInvoke(Method = "PUT",
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "/Update/{EmpId}")]
        string UpdateEmployee(EmployeeContract employeeContract, string empId);

    }
}
