// КОРЕКЦИИ:
// 1. Безкрайна рекурсия: new PlatformService().Create(item) -> PlatformsContext (DataLayer)
// 2. 'internal' -> 'public'

using BusinessLayer;
using DataLayer;

namespace ServiceLayer
{
    public class PlatformService
    {
        public void Create(Platform item)
        {
            try
            {
                PlatformsContext platformContext = new PlatformsContext(new GameManagerDbContext());
                platformContext.Create(item);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Platform Read(int key, bool useNavigationalProperties = false)
        {
            try
            {
                PlatformsContext platformContext = new PlatformsContext(new GameManagerDbContext());
                return platformContext.Read(key, useNavigationalProperties);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Platform> ReadAll(bool useNavigationalProperties = false)
        {
            try
            {
                PlatformsContext platformContext = new PlatformsContext(new GameManagerDbContext());
                return platformContext.ReadAll(useNavigationalProperties);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Platform item)
        {
            try
            {
                PlatformsContext platformContext = new PlatformsContext(new GameManagerDbContext());
                platformContext.Update(item);
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
                PlatformsContext platformContext = new PlatformsContext(new GameManagerDbContext());
                platformContext.Delete(key);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
