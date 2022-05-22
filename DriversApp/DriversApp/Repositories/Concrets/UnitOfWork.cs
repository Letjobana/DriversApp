using DriversApp.Data;
using DriversApp.Repositories.Abstracts;

namespace DriversApp.Repositories.Concrets
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext context;

        public IDriversRepository DriversRepository { get; private set; }

        public ISectionRepository SectionRepository { get; private set; }

        public IDepartmentRepository DepartmentRepository { get; private set; }

        public IManagerRepository ManagerRepository { get; private set; }

        public IRequirementRepository RequirementRepository { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            this.context = context;
            DriversRepository = new DriversRepository(context);
            SectionRepository = new SectionRepository(context);
            DepartmentRepository = new DepartmentRepository(context);
            ManagerRepository = new ManagerRepository(context);
            RequirementRepository = new RequirementRepository(context);
        }

    }
}
