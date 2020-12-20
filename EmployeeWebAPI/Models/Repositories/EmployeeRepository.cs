using EmployeeManagament.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeWebAPI.Models.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext context ; 

        public EmployeeRepository(AppDbContext context)
        {
            this.context = context; 
        }
        public async Task<Employee> AddEmployee(Employee employee)
        {
            var result = await context.Employees.AddAsync(employee);
            await context.SaveChangesAsync();
            return result.Entity; 
        }

        public async Task<Employee> DeleteEmployee(int employeeId)
        {
            var result = await context.Employees.FirstOrDefaultAsync(e => e.EmployeeID == employeeId);
            if (result !=null)
            {
                context.Employees.Remove(result);
                await context.SaveChangesAsync();
                return result;
            }
            return null; 
        }

        public async Task<Employee> GetEmployee(int employeeId)
        {
            var result = await context.Employees.FirstOrDefaultAsync(e => e.EmployeeID == employeeId);
            return result;
        }

        public async Task<Employee> GetEmployeeByEmail(string Email)
        {
            var result = await context.Employees.FirstOrDefaultAsync(e => e.Email == Email);
            return result;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            var result = await context.Employees.ToListAsync();
            return result; 
        }

        public async Task<IEnumerable<Employee>> Search(string name, Gender? gender)
        {
            IQueryable<Employee> query = context.Employees;

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(e => e.FirstName.Contains(name) || e.LastName.Contains(name));
            }
            if (gender != null)
            {
                query = query.Where(e => e.Gender == gender);
            }

            return await query.ToListAsync();
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var result = await context.Employees.FirstOrDefaultAsync(e => e.EmployeeID == employee.EmployeeID);
            if (result != null)
            {
                result.FirstName = employee.FirstName;
                result.LastName = employee.LastName;
                result.DateOfBirth = employee.DateOfBirth;
                result.Gender = employee.Gender;
                result.DepartementID = employee.DepartementID;
                result.PhotoPath = employee.PhotoPath;

                await context.SaveChangesAsync();
                return result;
            }
            return null;

        }
    }
}
