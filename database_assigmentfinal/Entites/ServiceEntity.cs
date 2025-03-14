using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace database_assigmentfinal.Entites
{
    public class ServiceEntity
    {
        public int Id { get; set; }
        public string ServiceName { get; set; } = null!;
        public decimal Price { get; set; }
    }
}
