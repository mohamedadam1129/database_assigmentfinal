using database_assigmentfinal.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace database_assigmentfinal.Repositories
{
    public class StatusRepository(Databasecontext context)
    {
        private readonly Databasecontext _context = context; 
    }
}
