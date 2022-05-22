using DriversApp.Data;
using DriversApp.Models;
using DriversApp.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DriversApp.Repositories.Concrets
{
    public class ManagerRepository : IManagerRepository
    {
        private readonly ApplicationDbContext context;

        public ManagerRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<Manager> GetAllManagers()
        {
            try
            {
                return context.Managers.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
