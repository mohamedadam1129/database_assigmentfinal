using database_assigmentfinal.DataContext;
using database_assigmentfinal.Entites;
using database_assigmentfinal.Repositories; 
using System.Threading.Tasks;

    public interface IServiceRepository : IBaseRepository<ServiceEntity>
    {
        
    }

    public class ServiceRepository : Baserepository<ServiceEntity>
    {
        public ServiceRepository(Databasecontext context) : base(context)
        {
         
        }

} 