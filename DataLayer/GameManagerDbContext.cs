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

        public static bool IsTestMode { get; set; } = false;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                if (IsTestMode)
                {
                    optionsBuilder.UseInMemoryDatabase("GameManagerTestDb");
                }
                else
                {
                    optionsBuilder.UseMySQL("Server=127.0.0.1;Database=GameManager;Uid=root;Pwd=123456789;");
                }
            }
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Game> Games { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Platform> Platforms { get; set; }

        public DbSet<Publisher> Publishers { get; set; }

        public DbSet<Studio> Studios { get; set; }

    }
}
