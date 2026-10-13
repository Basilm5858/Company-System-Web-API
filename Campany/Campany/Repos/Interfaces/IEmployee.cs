using Campany.DTOs;
using Campany.Models;

namespace Campany.Repos.Interfaces
{
    public interface IEmployee : IGenericRepo<Employee>
    {
        Task<ICollection<EmployeeDTO>> GetByName(string name);
        Task<ICollection<EmployeeDTO>> GetByDepId(int id);
    }
}
