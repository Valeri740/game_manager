// КОРЕКЦИИ:
// 1. Безкрайна рекурсия: new GenreService().Create(item) -> GenresContext (DataLayer)
// 2. Премахнато: using Org.BouncyCastle.Asn1.Cmp (ненужен пакет, грешка при компилация)

using BusinessLayer;
using DataLayer;

namespace ServiceLayer
{
    public class GenreService
    {
        public void Create(Genre item)
        {
            try
            {
                GenresContext genreContext = new GenresContext(new GameManagerDbContext());
                genreContext.Create(item);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Genre Read(int key, bool useNavigationalProperties = false)
        {
            try
            {
                GenresContext genreContext = new GenresContext(new GameManagerDbContext());
                return genreContext.Read(key, useNavigationalProperties);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Genre> ReadAll(bool useNavigationalProperties = false)
        {
            try
            {
                GenresContext genreContext = new GenresContext(new GameManagerDbContext());
                return genreContext.ReadAll(useNavigationalProperties);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Genre item)
        {
            try
            {
                GenresContext genreContext = new GenresContext(new GameManagerDbContext());
                genreContext.Update(item);
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
                GenresContext genreContext = new GenresContext(new GameManagerDbContext());
                genreContext.Delete(key);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
