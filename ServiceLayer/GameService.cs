// GameService.cs беше относително добре написан (единственият от 5-те).
// Единствената корекция: методите Read/ReadAll/Update бяха static —
// това е непоследователно и затруднява използването от MainForm.
// Направени са instance методи (без static).

using BusinessLayer;
using DataLayer;

namespace ServiceLayer
{
    public class GameService
    {
        public void Create(Game item)
        {
            try
            {
                GamesContext gamesContext = new GamesContext(new GameManagerDbContext());
                gamesContext.Create(item);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Game Read(int key, bool useNavigationalProperties = false)
        {
            try
            {
                GamesContext gamesContext = new GamesContext(new GameManagerDbContext());
                return gamesContext.Read(key, useNavigationalProperties);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Game> ReadAll(bool useNavigationalProperties = false)
        {
            try
            {
                GamesContext gamesContext = new GamesContext(new GameManagerDbContext());
                return gamesContext.ReadAll(useNavigationalProperties);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Game item)
        {
            try
            {
                GamesContext gamesContext = new GamesContext(new GameManagerDbContext());
                gamesContext.Update(item);
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
                GamesContext gamesContext = new GamesContext(new GameManagerDbContext());
                gamesContext.Delete(key);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
