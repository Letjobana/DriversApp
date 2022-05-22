using DriversApp.Data;
using DriversApp.Models;
using DriversApp.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DriversApp.Repositories.Concrets
{
    public class SectionRepository : ISectionRepository
    {
        private readonly ApplicationDbContext context;

        public SectionRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Section> GetAllSections()
        {
            try
            {
                return context.Sections.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
