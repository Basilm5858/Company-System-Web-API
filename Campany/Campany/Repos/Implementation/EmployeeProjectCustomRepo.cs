using Campany.Data;
using Campany.DTOs;
using Campany.Models;
using Campany.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Campany.Repos.Implementation
{
    public class EmployeeProjectCustomRepo : GenericRepo<EmployeeProject>, IEmployeeProject
    {
        private readonly My_AppContext _context;
        public EmployeeProjectCustomRepo(My_AppContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ICollection<EmployeeProjectDTO>> GetByEmpId(int empid)
        {
            return await _context.EmployeeProjects
                .Include(x => x.EmployeeId)
                .Include(x => x.Project)
                .Select(x => new EmployeeProjectDTO
                {
                    AssignedDate = x.AssignedDate,
                    AssignedRole = x.AssignedRole,
                    EmployeeId = x.EmployeeId,
                    ProjectId = x.ProjectId,
                    Id = x.Id
                }).ToListAsync();
        }
    }
}
