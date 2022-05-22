using DriversApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DriversApp.Repositories.Abstracts
{
    public interface IManagerRepository
    {
        IEnumerable<Manager> GetAllManagers();
    }
}
