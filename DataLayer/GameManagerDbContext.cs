using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using BusinessLayer;

namespace DataLayer
{
    public class GameManagerDbContext : DbContext
    {
        public GameManagerDbContext() : base() 
        {

        }

        public GameManagerDbContext(DbContextOptions options)
        : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("Server=127.0.0.1;Database=GameManager;Uid=root;Pwd=123456789;");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Game> Games { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Platform> Platforms { get; set; }

        public DbSet<Publisher> Publishers { get; set; }

        public DbSet<Studio> Studios { get; set; }

    }
}
