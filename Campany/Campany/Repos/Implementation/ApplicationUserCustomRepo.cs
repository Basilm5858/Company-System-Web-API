using Campany.Data;
using Campany.Models;
using Campany.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Campany.Repos.Implementation
{
    public class ApplicationUserCustomRepo : GenericRepo<ApplicationUser>, IApplicationUser
    {
        private readonly My_AppContext _context;
        public ApplicationUserCustomRepo(My_AppContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ApplicationUser?> GetByEmailAsync(string email)
        {
            return await _context.ApplicationUsers
                .FirstOrDefaultAsync(x => x.Email == email);
        }

    }
}
