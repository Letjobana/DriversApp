namespace DriversApp.Repositories.Abstracts
{
    public interface IUnitOfWork
    {
        public IDriversRepository DriversRepository { get; }
        public ISectionRepository SectionRepository { get; }
        public IDepartmentRepository DepartmentRepository { get; }
        public IManagerRepository ManagerRepository { get; }
        public IRequirementRepository RequirementRepository { get; }
    }
}
