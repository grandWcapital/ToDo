using Microsoft.EntityFrameworkCore;

namespace ToDoApp.Models
{
    public class ToDoAppDbContext : DbContext
    {
        public ToDoAppDbContext(DbContextOptions<ToDoAppDbContext> options)
            : base(options)
        {

        }
        public DbSet<Duty> Duties { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Priority> Priorities { get; set; }
    }
}
