using BusinessLayer;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System;

namespace ServiceLayer
{
    public class GenreService
    {
        public void Create(Genre item)
        {
            try
            {
                using var context = new GameManagerDbContext();
                context.Genres.Add(item);
                context.SaveChanges();
            }
            catch (Exception ex) { throw; }
        }

        public Genre Read(int key, bool useNavigationalProperties = false)
        {
            try
            {
                using var context = new GameManagerDbContext();
                IQueryable<Genre> query = context.Genres;
                if (useNavigationalProperties)
                {
                    query = query.Include(g => g.Games);
                }
                return query.FirstOrDefault(g => g.Genre_id == key) ?? throw new Exception("Genre not found");
            }
            catch (Exception ex) { throw; }
        }

        public IEnumerable<Genre> ReadAll(bool useNavigationalProperties = false)
        {
            try
            {
                using var context = new GameManagerDbContext();
                IQueryable<Genre> query = context.Genres;
                if (useNavigationalProperties)
                {
                    query = query.Include(g => g.Games);
                }
                return query.ToList();
            }
            catch (Exception ex) { throw; }
        }

        public void Update(Genre item)
        {
            try
            {
                using var context = new GameManagerDbContext();
                context.Genres.Update(item);
                context.SaveChanges();
            }
            catch (Exception ex) { throw; }
        }

        public void Delete(int key)
        {
            try
            {
                using var context = new GameManagerDbContext();
                var item = context.Genres.Find(key);
                if (item != null)
                {
                    context.Genres.Remove(item);
                    context.SaveChanges();
                }
            }
            catch (Exception ex) { throw; }
        }
    }
}
