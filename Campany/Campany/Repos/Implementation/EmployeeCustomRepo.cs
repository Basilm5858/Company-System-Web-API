using Campany.Data;
using Campany.DTOs;
using Campany.Models;
using Campany.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Campany.Repos.Implementation
{
    public class EmployeeCustomRepo : GenericRepo<Employee>, IEmployee
    {
        private readonly My_AppContext _context;
        public EmployeeCustomRepo(My_AppContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ICollection<EmployeeDTO>> GetByName(string name)
        {
            return await _context.Employees
                .Include(x => x.Department)
                .Where(x => x.FullName.Contains(name))
                .Select(x => new EmployeeDTO
                {
                    DepartmentId = x.DepartmentId,
                    Email = x.Email,
                    Salary = x.Salary,
                    FullName = x.FullName,
                    HireDate = x.HireDate,
                    Id = x.Id,
                }).ToListAsync();
        }
        public async Task<ICollection<EmployeeDTO>> GetByDepId(int id)
        {
            return await _context.Employees
                .Include(x => x.Department)
                .Where(x => x.DepartmentId == id)
                .Select(x => new EmployeeDTO
                {
                    DepartmentId = x.DepartmentId,
                    Email = x.Email,
                    Salary = x.Salary,
                    FullName = x.FullName,
                    HireDate = x.HireDate,
                    Id = x.Id,
                }).ToListAsync();
        }
    }
}
