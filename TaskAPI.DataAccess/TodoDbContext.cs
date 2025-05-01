using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskAPI.Models;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;


namespace TaskAPI.DataAccess
{
    public class TodoDbContext : DbContext
    {
        //adding Todos table
        public DbSet<Todo> Todos { get; set; }

        //connect to db
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=localhost;Database=MyTodoDb;User=root;Password=toor;";

            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
        public bool TestConnection()
        {
            try
            {
                return this.Database.CanConnect();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Database connection failed: {ex.Message}");
                return false;
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Todo>().HasData(new Todo
            {
                Id = 1,
                Title = "Get books - DB",
                Description = "Get some text books",
                CreatedDate = DateTime.Now,
                Due = DateTime.Now.AddDays(5),
                Status = TodoStatus.New
            });
        }



    }
}
