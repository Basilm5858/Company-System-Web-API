using Campany.Data;
using Campany.Repos.Interfaces;

namespace Campany.Repos.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        public IApplicationUser ApplicationUserCustomRepo { get; }

        public IProject ProjectCustomRepo { get; }

        public IEmployee EmployeeCustomRepo { get; }

        public IEmployeeProject EmployeeProjectCustomRepo { get; }

        public IDepartment DepartmentCustomRepo { get; }
        private readonly My_AppContext _context;

        public UnitOfWork(IApplicationUser applicationUserCustomRepo, IProject projectCustomRepo, IEmployee employeeCustomRepo, IEmployeeProject employeeProjectCustomRepo, IDepartment departmentCustomRepo, My_AppContext context)
        {
            ApplicationUserCustomRepo = applicationUserCustomRepo;
            ProjectCustomRepo = projectCustomRepo;
            EmployeeCustomRepo = employeeCustomRepo;
            EmployeeProjectCustomRepo = employeeProjectCustomRepo;
            DepartmentCustomRepo = departmentCustomRepo;
            _context = context;
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
