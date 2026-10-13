using Campany.Repos.Implementation;

namespace Campany.Repos.Interfaces
{
    public interface IUnitOfWork
    {
        ApplicationUserCustomRepo ApplicationUserCustomRepo { get; }
        ProjectCustomRepo ProjectCustomRepo { get; }
        EmployeeCustomRepo EmployeeCustomRepo { get; }
        EmployeeProjectCustomRepo EmployeeProjectCustomRepo { get; }
        DepartmentCustomRepo DepartmentCustomRepo { get; }
        Task SaveChanges();
    }
}
