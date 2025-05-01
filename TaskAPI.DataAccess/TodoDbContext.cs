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
        public DbSet<Author> Authors { get; set; }

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
            modelBuilder.Entity<Author>().HasData(new Author[]
            {
                new Author { Id = 1,FullName="Sucharitha Gamlath" },
                new Author { Id = 2,FullName="Wasana Bandara" },
                new Author { Id = 3,FullName="Mahagama Sekara" },
                new Author { Id = 4,FullName="Martin Wickramasinghe" }
            }
            );

            modelBuilder.Entity<Todo>().HasData(new Todo[]
            {   new Todo
                    {
                    Id = 1,
                    Title = "Get books - DB",
                    Description = "Get some text books",
                    CreatedDate = DateTime.Now,
                    Due = DateTime.Now.AddDays(5),
                    Status = TodoStatus.New,
                    AuthorId = 1
                    },
                    new Todo
                    {
                    Id = 2,
                    Title = "Buy vegetables - DB",
                    Description = "Buy vegetables for the week ",
                    CreatedDate = DateTime.Now,
                    Due = DateTime.Now.AddDays(5),
                    Status = TodoStatus.New,
                    AuthorId = 1
                    },
                    new Todo
                    {
                    Id = 3,
                    Title = "Watering to plants - DB",
                    Description = "Water to plants in the evening",
                    CreatedDate = DateTime.Now,
                    Due = DateTime.Now.AddDays(5),
                    Status = TodoStatus.New,
                    AuthorId = 2
                    }
            });
        }



    }
}
