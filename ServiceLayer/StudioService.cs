// КОРЕКЦИИ:
// 1. Безкрайна рекурсия: new StudioService().Create(item) извикваше само себе си
//    -> Заменено с StudiosContext (DataLayer) който реално пише в базата
// 2. 'internal' -> 'public' (иначе PresentationLayer не може да го ползва)

using BusinessLayer;
using DataLayer;

namespace ServiceLayer
{
    public class StudioService
    {
        public void Create(Studio item)
        {
            try
            {
                StudiosContext studioContext = new StudiosContext(new GameManagerDbContext());
                studioContext.Create(item);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Studio Read(int key, bool useNavigationalProperties = false)
        {
            try
            {
                StudiosContext studioContext = new StudiosContext(new GameManagerDbContext());
                return studioContext.Read(key, useNavigationalProperties);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Studio> ReadAll(bool useNavigationalProperties = false)
        {
            try
            {
                StudiosContext studioContext = new StudiosContext(new GameManagerDbContext());
                return studioContext.ReadAll(useNavigationalProperties);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Studio item)
        {
            try
            {
                StudiosContext studioContext = new StudiosContext(new GameManagerDbContext());
                studioContext.Update(item);
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
                StudiosContext studioContext = new StudiosContext(new GameManagerDbContext());
                studioContext.Delete(key);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
