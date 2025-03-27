using Database_assigment.Entites;
using database_assigmentfinal.DataContext;
using database_assigmentfinal.Repositories; 
using System.Threading.Tasks;

namespace database_assigmentfinal.Repositories
{
    public interface ICustomerRepository : IBaseRepository<CustomerEntity>
    {

    }

    public class CustomerRepository : Baserepository<CustomerEntity> 
    {
        public CustomerRepository(Databasecontext context) : base(context)
        {
            
        }

      
    }
}