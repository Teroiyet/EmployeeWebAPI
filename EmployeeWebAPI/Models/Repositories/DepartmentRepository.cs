using EmployeeManagament.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeWebAPI.Models.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext context;

        public DepartmentRepository(AppDbContext context)
        {
            this.context = context; 
        }
        public Department GetDepartment(int departmentId)
        {
            var result = context.Departments.FirstOrDefault(d => d.DepartementID == departmentId);
            return result;
        }

        public IEnumerable<Department> GetDepartments()
        {
            var result = context.Departments;
            return result;
        }
    }
}
