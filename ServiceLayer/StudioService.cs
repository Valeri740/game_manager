using BusinessLayer;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System;

namespace ServiceLayer
{
    public class StudioService
    {
        public void Create(Studio item)
        {
            try
            {
                using var context = new GameManagerDbContext();
                context.Studios.Add(item);
                context.SaveChanges();
            }
            catch (Exception ex) { throw; }
        }

        public Studio Read(int key, bool useNavigationalProperties = false)
        {
            try
            {
                using var context = new GameManagerDbContext();
                IQueryable<Studio> query = context.Studios;
                if (useNavigationalProperties)
                {
                    query = query.Include(s => s.Games);
                }
                return query.FirstOrDefault(s => s.Studio_id == key) ?? throw new Exception("Studio not found");
            }
            catch (Exception ex) { throw; }
        }

        public IEnumerable<Studio> ReadAll(bool useNavigationalProperties = false)
        {
            try
            {
                using var context = new GameManagerDbContext();
                IQueryable<Studio> query = context.Studios;
                if (useNavigationalProperties)
                {
                    query = query.Include(s => s.Games);
                }
                return query.ToList();
            }
            catch (Exception ex) { throw; }
        }

        public void Update(Studio item)
        {
            try
            {
                using var context = new GameManagerDbContext();
                context.Studios.Update(item);
                context.SaveChanges();
            }
            catch (Exception ex) { throw; }
        }

        public void Delete(int key)
        {
            try
            {
                using var context = new GameManagerDbContext();
                var item = context.Studios.Find(key);
                if (item != null)
                {
                    context.Studios.Remove(item);
                    context.SaveChanges();
                }
            }
            catch (Exception ex) { throw; }
        }
    }
}
