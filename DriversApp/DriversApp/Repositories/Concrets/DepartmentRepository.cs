using DriversApp.Data;
using DriversApp.Models;
using DriversApp.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DriversApp.Repositories.Concrets
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext context;

        public DepartmentRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<Department> GetAllDepartments()
        {
            try
            {
                return context.Departments.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
