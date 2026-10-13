using Campany.Models;

namespace Campany.Repos.Interfaces
{
    public interface IApplicationUser : IGenericRepo<ApplicationUser>
    {
        Task<ApplicationUser?> GetByEmailAsync(string name);
    }
}
