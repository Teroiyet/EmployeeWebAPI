using EmployeeManagament.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeWebAPI.Models.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployees();

        Task<Employee> GetEmployee(int employeeId);

        Task<Employee> AddEmployee(Employee employee);

        Task<Employee> UpdateEmployee(Employee employee);

        Task<Employee> DeleteEmployee(int employeeId);

        Task<Employee> GetEmployeeByEmail(string Email);
        Task<IEnumerable<Employee>> Search(string name , Gender? gender);

    }
}
