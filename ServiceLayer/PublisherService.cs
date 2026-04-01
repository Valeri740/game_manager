// КОРЕКЦИИ:
// 1. Безкрайна рекурсия: new PublisherService().Create(item) -> PublishersContext (DataLayer)
// 2. 'internal' -> 'public'

using BusinessLayer;
using DataLayer;

namespace ServiceLayer
{
    public class PublisherService
    {
        public void Create(Publisher item)
        {
            try
            {
                PublishersContext publisherContext = new PublishersContext(new GameManagerDbContext());
                publisherContext.Create(item);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Publisher Read(int key, bool useNavigationalProperties = false)
        {
            try
            {
                PublishersContext publisherContext = new PublishersContext(new GameManagerDbContext());
                return publisherContext.Read(key, useNavigationalProperties);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Publisher> ReadAll(bool useNavigationalProperties = false)
        {
            try
            {
                PublishersContext publisherContext = new PublishersContext(new GameManagerDbContext());
                return publisherContext.ReadAll(useNavigationalProperties);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Publisher item)
        {
            try
            {
                PublishersContext publisherContext = new PublishersContext(new GameManagerDbContext());
                publisherContext.Update(item);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(int key)
        {
            try
            {
                PublishersContext publisherContext = new PublishersContext(new GameManagerDbContext());
                publisherContext.Delete(key);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
