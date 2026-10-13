using Campany.Data;
using Campany.Models;
using Campany.Repos.Interfaces;

namespace Campany.Repos.Implementation
{
    public class ProjectCustomRepo : GenericRepo<Project>, IProject
    {
        public ProjectCustomRepo(My_AppContext context) : base(context)
        {
        }
    }
}
