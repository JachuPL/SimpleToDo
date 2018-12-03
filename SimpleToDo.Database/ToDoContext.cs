using Microsoft.EntityFrameworkCore;
using SimpleToDo.Database.Configurations;
using SimpleToDo.Models.Domain;

namespace SimpleToDo.Database
{
    public class ToDoContext : DbContext
    {
        public DbSet<ToDoTask> Tasks { get; set; }

        public ToDoContext(DbContextOptions<ToDoContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ToDoTaskConfiguration());
        }
    }
}