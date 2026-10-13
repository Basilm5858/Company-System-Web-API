using Campany.Data;
using Campany.Repos.Interfaces;

namespace Campany.Repos.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        public ApplicationUserCustomRepo ApplicationUserCustomRepo { get; }

        public ProjectCustomRepo ProjectCustomRepo { get; }

        public EmployeeCustomRepo EmployeeCustomRepo { get; }

        public EmployeeProjectCustomRepo EmployeeProjectCustomRepo { get; }

        public DepartmentCustomRepo DepartmentCustomRepo { get; }
        private readonly My_AppContext _context;

        public UnitOfWork(ApplicationUserCustomRepo applicationUserCustomRepo, ProjectCustomRepo projectCustomRepo, EmployeeCustomRepo employeeCustomRepo, EmployeeProjectCustomRepo employeeProjectCustomRepo, DepartmentCustomRepo departmentCustomRepo, My_AppContext context)
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
