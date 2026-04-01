// КОРЕКЦИЯ: Файлът съдържаше всичките 5 класа наново (без namespace!) 
// което причиняваше "type already defined" грешки.
// Сега съдържа само PublishersContext в правилния namespace.

using System;
using System.Collections.Generic;
using BusinessLayer;

namespace DataLayer
{
    public class PublishersContext : IDb<Publisher, int>
    {
        private GameManagerDbContext dbContext;

        public PublishersContext(GameManagerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Create(Publisher item)
        {
            dbContext.Publishers.Add(item);
            dbContext.SaveChanges();
        }

        public Publisher Read(int key, bool useNavigationalProperties = false, bool isReadOnly = false)
        {
            var publisher = dbContext.Publishers.Find(key);

            if (publisher == null)
                throw new ArgumentException("Publisher not found");

            return publisher;
        }

        public List<Publisher> ReadAll(bool useNavigationalProperties = false, bool isReadOnly = false)
        {
            return dbContext.Publishers.ToList();
        }

        public void Update(Publisher item, bool useNavigationalProperties = false)
        {
            var publisher = Read(item.Publisher_id);
            dbContext.Entry(publisher).CurrentValues.SetValues(item);
            dbContext.SaveChanges();
        }

        public void Delete(int key)
        {
            var publisher = Read(key);
            dbContext.Publishers.Remove(publisher);
            dbContext.SaveChanges();
        }
    }
}
