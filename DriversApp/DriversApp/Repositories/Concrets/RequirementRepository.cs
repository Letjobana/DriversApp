using DriversApp.Data;
using DriversApp.Models;
using DriversApp.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DriversApp.Repositories.Concrets
{
    public class RequirementRepository : IRequirementRepository
    {
        private readonly ApplicationDbContext context;

        public RequirementRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<Requirement> GetAllRequirement()
        {
            try
            {
                return context.Requirements.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
