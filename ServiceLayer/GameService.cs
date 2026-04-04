using BusinessLayer;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System;

namespace ServiceLayer
{
    public class GameService
    {
        public void Create(Game item)
        {
            try
            {
                using var context = new GameManagerDbContext();
                context.Games.Add(item);
                context.SaveChanges();
            }
            catch (Exception ex) { throw; }
        }

        public Game Read(int key, bool useNavigationalProperties = false)
        {
            try
            {
                using var context = new GameManagerDbContext();
                IQueryable<Game> query = context.Games;
                if (useNavigationalProperties)
                {
                    query = query.Include(g => g.Studio)
                                 .Include(g => g.Genres)
                                 .Include(g => g.Platforms);
                }
                return query.FirstOrDefault(g => g.Id == key) ?? throw new Exception("Game not found");
            }
            catch (Exception ex) { throw; }
        }

        public IEnumerable<Game> ReadAll(bool useNavigationalProperties = false)
        {
            try
            {
                using var context = new GameManagerDbContext();
                IQueryable<Game> query = context.Games;
                if (useNavigationalProperties)
                {
                    query = query.Include(g => g.Studio)
                                 .Include(g => g.Genres)
                                 .Include(g => g.Platforms);
                }
                return query.ToList();
            }
            catch (Exception ex) { throw; }
        }

        public void Update(Game item)
        {
            try
            {
                using var context = new GameManagerDbContext();
                context.Games.Update(item);
                context.SaveChanges();
            }
            catch (Exception ex) { throw; }
        }

        public void Delete(int key)
        {
            try
            {
                using var context = new GameManagerDbContext();
                var item = context.Games.Find(key);
                if (item != null)
                {
                    context.Games.Remove(item);
                    context.SaveChanges();
                }
            }
            catch (Exception ex) { throw; }
        }
    }
}
