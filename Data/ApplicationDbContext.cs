using Microsoft.EntityFrameworkCore;
using ToDoList.Models;

namespace ToDoList.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<ToDo> ToDos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);


            var bulider = new ConfigurationBuilder().AddJsonFile("appsettings.json", true, true).Build();

            var connectionString = bulider.GetConnectionString("defulatConnection");

            optionsBuilder.UseSqlServer(connectionString);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>()
                .
                 HasMany(e => e.toDos)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserId)
                .IsRequired();


        }
    }
}
