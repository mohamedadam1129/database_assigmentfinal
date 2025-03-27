using database_assigmentfinal.DataContext;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace database_assigmentfinal.Repositories
{
    public interface IProjectRepository : IBaseRepository<Project>
    {
        
    }

    public class ProjectRepository : Baserepository<Project>, IProjectRepository
    {
        public ProjectRepository(Databasecontext context) : base(context)
        {
        }

        
    }
}