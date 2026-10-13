using Campany.Repos.Implementation;

namespace Campany.Repos.Interfaces
{
    public interface IUnitOfWork
    {
        IApplicationUser ApplicationUserCustomRepo { get; }
        IProject ProjectCustomRepo { get; }
        IEmployee EmployeeCustomRepo { get; }
        IEmployeeProject EmployeeProjectCustomRepo { get; }
        IDepartment DepartmentCustomRepo { get; }
        Task SaveChanges();
    }
}
