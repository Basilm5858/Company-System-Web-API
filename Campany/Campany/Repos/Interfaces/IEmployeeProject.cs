using Campany.DTOs;
using Campany.Models;

namespace Campany.Repos.Interfaces
{
    public interface IEmployeeProject : IGenericRepo<EmployeeProject>
    {
        Task<ICollection<EmployeeProjectDTO>> GetByEmpId(int empid);
    }
}
