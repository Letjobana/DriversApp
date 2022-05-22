using DriversApp.Models;
using System.Collections.Generic;

namespace DriversApp.Repositories.Abstracts
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> GetAllDepartments();
    }
}
