// КОРЕКЦИЯ: Премахнат празният { } блок който беше след using-ите (синтаксна грешка)

using System;
using System.Collections.Generic;
using System.Text;
using BusinessLayer;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class GenresContext : IDb<Genre, int>
    {
        private GameManagerDbContext dbContext;

        public GenresContext(GameManagerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Create(Genre item)
        {
            dbContext.Genres.Add(item);
            dbContext.SaveChanges();
        }

        public Genre Read(int key, bool useNavigationalProperties = false, bool isReadOnly = false)
        {
            IQueryable<Genre> query = dbContext.Genres;

            if (useNavigationalProperties)
                query = query.Include(g => g.Games);

            if (isReadOnly)
                query = query.AsNoTrackingWithIdentityResolution();

            var genre = query.FirstOrDefault(g => g.Genre_id == key);

            if (genre == null)
                throw new ArgumentException("Genre not found");

            return genre;
        }

        public List<Genre> ReadAll(bool useNavigationalProperties = false, bool isReadOnly = false)
        {
            return dbContext.Genres.ToList();
        }

        public void Update(Genre item, bool useNavigationalProperties = false)
        {
            var genre = Read(item.Genre_id);
            dbContext.Entry(genre).CurrentValues.SetValues(item);
            dbContext.SaveChanges();
        }

        public void Delete(int key)
        {
            var genre = Read(key);
            dbContext.Genres.Remove(genre);
            dbContext.SaveChanges();
        }
    }
}
