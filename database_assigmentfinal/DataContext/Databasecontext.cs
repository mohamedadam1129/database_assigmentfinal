using Microsoft.EntityFrameworkCore;
using database_assigmentfinal; 

namespace database_assigmentfinal.DataContext
{
    public class Databasecontext : DbContext
    {
        public DbSet<Project> Projects { get; set; } 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\moomea\\source\\repos\\database_assigmentfinal\\database_assigmentfinal\\DataContext\\Database\\locall_db.mdf;Integrated Security=True;Connect Timeout=30");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>()
                .Property(p => p.ProjectNumber)
                .ValueGeneratedNever();
        }
    }
}