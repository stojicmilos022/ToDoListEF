using Microsoft.EntityFrameworkCore;

namespace ToDoEf.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<ToDoGroup> Groups { get; set; }
        public DbSet<ToDoItems> Items { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDoGroup>().HasData(
                new ToDoGroup { Id = 1, Name = "Learn the basics of C#" }); ;


            modelBuilder.Entity<ToDoItems>().HasData(
                new ToDoItems { Id = 1, Name = "C#", GroupId=1 },
                new ToDoItems { Id = 2,Name=".NET", GroupId = 1 },
                new ToDoItems { Id = 3, Name = ".NET CLI", GroupId = 1 }


            );

            base.OnModelCreating(modelBuilder);
        }
    }


}
