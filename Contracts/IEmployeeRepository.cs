using Entities.Models;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IEmployeeRepository
    {
        Task<Employee> GetEmployeeAsync(Guid companyId, Guid id, bool trackChanges);
        Task<PagedList<Employee>> GetEmployeesAsync(Guid companyId,
            EmployeeParameters employeeParameters, bool trackChanges);
        void CreateEmployeeForCompany(Guid companyId, Employee employee); //not async
        void DeleteEmployee(Employee employee); //not async
  

    }
}
