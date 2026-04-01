using System;
using System.Collections.Generic;
using System.Text;
using BusinessLayer;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class StudiosContext : IDb<Studio, int>
    {
        private GameManagerDbContext dbContext;

        public StudiosContext(GameManagerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Create(Studio item)
        {
            dbContext.Studios.Add(item);
            dbContext.SaveChanges();
        }

        public Studio Read(int key, bool useNavigationalProperties = false, bool isReadOnly = false)
        {
            var studio = dbContext.Studios.Find(key);

            if (studio == null)
                throw new ArgumentException("Studio not found");

            return studio;
        }

        public List<Studio> ReadAll(bool useNavigationalProperties = false, bool isReadOnly = false)
        {
            return dbContext.Studios.ToList();
        }

        public void Update(Studio item, bool useNavigationalProperties = false)
        {
            var studio = Read(item.Studio_id);
            dbContext.Entry(studio).CurrentValues.SetValues(item);
            dbContext.SaveChanges();
        }

        public void Delete(int key)
        {
            var studio = Read(key);
            dbContext.Studios.Remove(studio);
            dbContext.SaveChanges();
        }
    }
}
