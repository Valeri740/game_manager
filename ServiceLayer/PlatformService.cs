using BusinessLayer;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System;

namespace ServiceLayer
{
    public class PlatformService
    {
        public void Create(Platform item)
        {
            try
            {
                using var context = new GameManagerDbContext();
                context.Platforms.Add(item);
                context.SaveChanges();
            }
            catch (Exception ex) { throw; }
        }

        public Platform Read(int key, bool useNavigationalProperties = false)
        {
            try
            {
                using var context = new GameManagerDbContext();
                IQueryable<Platform> query = context.Platforms;
                if (useNavigationalProperties)
                {
                    query = query.Include(p => p.Games);
                }
                return query.FirstOrDefault(p => p.Id == key) ?? throw new Exception("Platform not found");
            }
            catch (Exception ex) { throw; }
        }

        public IEnumerable<Platform> ReadAll(bool useNavigationalProperties = false)
        {
            try
            {
                using var context = new GameManagerDbContext();
                IQueryable<Platform> query = context.Platforms;
                if (useNavigationalProperties)
                {
                    query = query.Include(p => p.Games);
                }
                return query.ToList();
            }
            catch (Exception ex) { throw; }
        }

        public void Update(Platform item)
        {
            try
            {
                using var context = new GameManagerDbContext();
                context.Platforms.Update(item);
                context.SaveChanges();
            }
            catch (Exception ex) { throw; }
        }

        public void Delete(int key)
        {
            try
            {
                using var context = new GameManagerDbContext();
                var item = context.Platforms.Find(key);
                if (item != null)
                {
                    context.Platforms.Remove(item);
                    context.SaveChanges();
                }
            }
            catch (Exception ex) { throw; }
        }
    }
}
