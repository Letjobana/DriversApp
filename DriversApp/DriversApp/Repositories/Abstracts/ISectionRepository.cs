using DriversApp.Models;
using System.Collections.Generic;

namespace DriversApp.Repositories.Abstracts
{
    public interface ISectionRepository
    {
        IEnumerable<Section> GetAllSections();
    }
}
