using System.Data.Entity;
using Business_layer;

public class GamesContext : IDb<Game, int>
{
    private AppDbContext dbContext;

    public GamesContext(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public void Create(Game item)
    {
        // Platforms
        List<Platform> platforms = new List<Platform>();
        foreach (var p in item.Platforms)
        {
            var platformFromDb = dbContext.Platforms.Find(p.Id);
            platforms.Add(platformFromDb ?? p);
        }
        item.Platforms = platforms;

        // Genres
        List<Genre> genres = new List<Genre>();
        foreach (var g in item.Genres)
        {
            var genreFromDb = dbContext.Genres.Find(g.Genre_id);
            genres.Add(genreFromDb ?? g);
        }
        item.Genres = genres;

        dbContext.Games.Add(item);
        dbContext.SaveChanges();
    }

    public Game Read(int key, bool useNavigationalProperties = false, bool isReadOnly = false)
    {
        IQueryable<Game> query = dbContext.Games;

        if (useNavigationalProperties)
            query = query.Include(g => g.Platforms)
                         .Include(g => g.Genres);

        if (isReadOnly)
            query = query.AsNoTrackingWithIdentityResolution();

        Game game = query.FirstOrDefault(g => g.Id == key);

        if (game == null)
            throw new ArgumentException("Game not found");

        return game;
    }

    public List<Game> ReadAll(bool useNavigationalProperties = false, bool isReadOnly = false)
    {
        IQueryable<Game> query = dbContext.Games;

        if (useNavigationalProperties)
            query = query.Include(g => g.Platforms)
                         .Include(g => g.Genres);

        if (isReadOnly)
            query = query.AsNoTrackingWithIdentityResolution();

        return query.ToList();
    }

    public void Update(Game item, bool useNavigationalProperties = false)
    {
        var gameFromDb = Read(item.Id, useNavigationalProperties);
        dbContext.Entry(gameFromDb).CurrentValues.SetValues(item);

        dbContext.SaveChanges();
    }

    public void Delete(int key)
    {
        var game = Read(key);
        dbContext.Games.Remove(game);
        dbContext.SaveChanges();
    }
}

public class GenresContext : IDb<Genre, int>
{
    private AppDbContext dbContext;

    public GenresContext(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public void Create(Genre item)
    {
        dbContext.Genres.Add(item);
        dbContext.SaveChanges();
    }

    public Genre Read(int key, bool useNavigationalProperties = false, bool isReadOnly = false)
    {
        IQueryable<Genre> query = dbContext.Genres;

        if (useNavigationalProperties)
            query = query.Include(g => g.Games);

        if (isReadOnly)
            query = query.AsNoTrackingWithIdentityResolution();

        var genre = query.FirstOrDefault(g => g.Genre_id == key);

        if (genre == null)
            throw new ArgumentException("Genre not found");

        return genre;
    }

    public List<Genre> ReadAll(bool useNavigationalProperties = false, bool isReadOnly = false)
    {
        return dbContext.Genres.ToList();
    }

    public void Update(Genre item, bool useNavigationalProperties = false)
    {
        var genre = Read(item.Genre_id);
        dbContext.Entry(genre).CurrentValues.SetValues(item);
        dbContext.SaveChanges();
    }

    public void Delete(int key)
    {
        var genre = Read(key);
        dbContext.Genres.Remove(genre);
        dbContext.SaveChanges();
    }
}

public class PlatformsContext : IDb<Platform, int>
{
    private AppDbContext dbContext;

    public PlatformsContext(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public void Create(Platform item)
    {
        dbContext.Platforms.Add(item);
        dbContext.SaveChanges();
    }

    public Platform Read(int key, bool useNavigationalProperties = false, bool isReadOnly = false)
    {
        var platform = dbContext.Platforms.Find(key);

        if (platform == null)
            throw new ArgumentException("Platform not found");

        return platform;
    }

    public List<Platform> ReadAll(bool useNavigationalProperties = false, bool isReadOnly = false)
    {
        return dbContext.Platforms.ToList();
    }

    public void Update(Platform item, bool useNavigationalProperties = false)
    {
        var platform = Read(item.Id);
        dbContext.Entry(platform).CurrentValues.SetValues(item);
        dbContext.SaveChanges();
    }

    public void Delete(int key)
    {
        var platform = Read(key);
        dbContext.Platforms.Remove(platform);
        dbContext.SaveChanges();
    }
}

public class StudiosContext : IDb<Studio, int>
{
    private AppDbContext dbContext;

    public StudiosContext(AppDbContext dbContext)
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

public class PublishersContext : IDb<Publisher, int>
{
    private AppDbContext dbContext;

    public PublishersContext(AppDbContext dbContext)
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
