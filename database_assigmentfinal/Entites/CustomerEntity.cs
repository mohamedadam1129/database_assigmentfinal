
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database_assigment.Entites
{
    public class CustomerEntity
    {
        public int Id { get; set; }
        public string CustomerName { get; set; } = null!;
    }

    public class ProjectEntity
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime EndDate { get; set; }


        public int CustomerID { get; set; }
        public string CustomerName { get; set; } = null!;

        public int StatusType { get; set; }
        public string Status { get; set; } = null!;

        public int UserId { get; set; }
        public string User { get; set; } = null!;


        public int ServiceID { get; set; }
        public string Service { get; set; } = null!;
    }

}
