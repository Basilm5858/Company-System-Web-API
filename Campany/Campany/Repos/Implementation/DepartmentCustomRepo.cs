using Campany.Data;
using Campany.Models;
using Campany.Repos.Interfaces;

namespace Campany.Repos.Implementation
{
    public class DepartmentCustomRepo : GenericRepo<Department>, IDepartment
    {
        public DepartmentCustomRepo(My_AppContext context) : base(context)
        {
        }
    }
}
