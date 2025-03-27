using database_assigmentfinal.DataContext;
using database_assigmentfinal.Entites;
using database_assigmentfinal.Repositories;
using System.Threading.Tasks;

namespace database_assigmentfinal.Repositories
{
    public interface IUserRepository : IBaseRepository<UserEntity>
    {
        
        
    }
    public class UserRepository : Baserepository<UserEntity>, IUserRepository
    {
        public UserRepository(Databasecontext context) : base(context)
        {
            
        }


    }
}
