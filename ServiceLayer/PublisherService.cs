using BusinessLayer;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System;

namespace ServiceLayer
{
    public class PublisherService
    {
        public void Create(Publisher item)
        {
            try
            {
                using var context = new GameManagerDbContext();
                context.Publishers.Add(item);
                context.SaveChanges();
            }
            catch (Exception ex) { throw; }
        }

        public Publisher Read(int key, bool useNavigationalProperties = false)
        {
            try
            {
                using var context = new GameManagerDbContext();
                IQueryable<Publisher> query = context.Publishers;
                // Publisher is the principal without nav props in the original model, 
                // but if there are nav properties, include them here. 
                // (e.g. if Publisher has Games later, query.Include(p => p.Games))
                return query.FirstOrDefault(p => p.Publisher_id == key) ?? throw new Exception("Publisher not found");
            }
            catch (Exception ex) { throw; }
        }

        public IEnumerable<Publisher> ReadAll(bool useNavigationalProperties = false)
        {
            try
            {
                using var context = new GameManagerDbContext();
                IQueryable<Publisher> query = context.Publishers;
                return query.ToList();
            }
            catch (Exception ex) { throw; }
        }

        public void Update(Publisher item)
        {
            try
            {
                using var context = new GameManagerDbContext();
                context.Publishers.Update(item);
                context.SaveChanges();
            }
            catch (Exception ex) { throw; }
        }

        public void Delete(int key)
        {
            try
            {
                using var context = new GameManagerDbContext();
                var item = context.Publishers.Find(key);
                if (item != null)
                {
                    context.Publishers.Remove(item);
                    context.SaveChanges();
                }
            }
            catch (Exception ex) { throw; }
        }
    }
}
