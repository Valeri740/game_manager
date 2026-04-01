using System;
using System.Collections.Generic;
using System.Text;
using BusinessLayer;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class GamesContext : IDb<Game, int>
    {
        public GameManagerDbContext dbContext;

        public GamesContext()
        {
            this.dbContext = new GameManagerDbContext();
        }

        public GamesContext(GameManagerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Create(Game item)
        {
            // Platforms
            List<Platform> platforms = new List<Platform>();
            foreach (var p in item.Platforms)
            {
                var platformFromDb = dbContext.Platforms.Find(p.Id);
                platforms.Add(platformFromDb ?? p);
            }
            item.Platforms = platforms;

            // Genres
            List<Genre> genres = new List<Genre>();
            foreach (var g in item.Genres)
            {
                var genreFromDb = dbContext.Genres.Find(g.Genre_id);
                genres.Add(genreFromDb ?? g);
            }
            item.Genres = genres;

            dbContext.Games.Add(item);
            dbContext.SaveChanges();
        }

        public Game Read(int key, bool useNavigationalProperties = false, bool isReadOnly = false)
        {
            IQueryable<Game> query = dbContext.Games;

            if (useNavigationalProperties)
                query = query.Include(g => g.Platforms)
                             .Include(g => g.Genres);

            if (isReadOnly)
                query = query.AsNoTrackingWithIdentityResolution();

            Game game = query.FirstOrDefault(g => g.Id == key);

            if (game == null)
                throw new ArgumentException("Game not found");

            return game;
        }

        public List<Game> ReadAll(bool useNavigationalProperties = false, bool isReadOnly = false)
        {
            IQueryable<Game> query = dbContext.Games;

            if (useNavigationalProperties)
                query = query.Include(g => g.Platforms)
                             .Include(g => g.Genres);

            if (isReadOnly)
                query = query.AsNoTrackingWithIdentityResolution();

            return query.ToList();
        }

        public void Update(Game item, bool useNavigationalProperties = false)
        {
            var gameFromDb = Read(item.Id, useNavigationalProperties);
            dbContext.Entry(gameFromDb).CurrentValues.SetValues(item);

            dbContext.SaveChanges();
        }

        public void Delete(int key)
        {
            var game = Read(key);
            dbContext.Games.Remove(game);
            dbContext.SaveChanges();
        }
    }
}
