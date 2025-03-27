using database_assigmentfinal.DataContext;
using database_assigmentfinal.Entites;
using database_assigmentfinal.Repositories; 
using System.Threading.Tasks;

namespace database_assigmentfinal.Repositories
{
    public interface IStatusTypeRepository : IBaseRepository<StatusType>
    {

    }

    public class StatusTypeRepository : Baserepository<StatusType>
    {
        public StatusTypeRepository(Databasecontext context) : base(context)
        {



        }
    }
}