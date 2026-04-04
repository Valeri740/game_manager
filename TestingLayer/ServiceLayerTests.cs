using NUnit.Framework;
using BusinessLayer;
using ServiceLayer;
using DataLayer;
using System.Linq;

namespace TestingLayer
{
    [TestFixture]
    public class ServiceLayerTests
    {
        [SetUp]
        public void Setup()
        {
            GameManagerDbContext.IsTestMode = true;
            using var context = new GameManagerDbContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }

        [Test]
        public void GameService_CreateAndRead_Works()
        {
            var service = new GameService();
            var game = new Game("Witcher 3", 2015, 1, 39.99m, 10);
            game.Multiplayer = "No";
            
            service.Create(game);
            
            var allGames = service.ReadAll().ToList();
            Assert.That(allGames.Count, Is.EqualTo(1));
            Assert.That(allGames[0].Title, Is.EqualTo("Witcher 3"));

            var readGame = service.Read(allGames[0].Id);
            Assert.That(readGame.Title, Is.EqualTo("Witcher 3"));
        }

        [Test]
        public void GameService_UpdateAndDelete_Works()
        {
            var service = new GameService();
            var game = new Game("Delete Me", 2000, 1, 10m, 5);
            game.Multiplayer = "Yes";
            service.Create(game);

            var added = service.ReadAll().First();
            added.Title = "Updated Title";
            service.Update(added);

            var updated = service.Read(added.Id);
            Assert.That(updated.Title, Is.EqualTo("Updated Title"));

            service.Delete(updated.Id);
            var allGames = service.ReadAll().ToList();
            Assert.That(allGames.Count, Is.EqualTo(0));
        }

        [Test]
        public void StudioService_CRUD_Works()
        {
            var service = new StudioService();
            var studio = new Studio("Valve", "USA", "1996", "valvesoftware.com");
            
            service.Create(studio);
            var all = service.ReadAll().ToList();
            Assert.That(all.Count, Is.EqualTo(1));

            var added = all[0];
            added.Country = "United States";
            service.Update(added);
            
            var updated = service.Read(added.Studio_id);
            Assert.That(updated.Country, Is.EqualTo("United States"));

            service.Delete(updated.Studio_id);
            Assert.That(service.ReadAll().ToList().Count, Is.EqualTo(0));
        }

        [Test]
        public void GenreService_CRUD_Works()
        {
            var service = new GenreService();
            var genre = new Genre(0, "Action", "Action games", new System.Collections.Generic.List<Game>());
            
            service.Create(genre);
            var all = service.ReadAll().ToList();
            Assert.That(all.Count, Is.EqualTo(1));

            var added = all[0];
            added.Name = "Action-Adventure";
            service.Update(added);
            
            var updated = service.Read(added.Genre_id);
            Assert.That(updated.Name, Is.EqualTo("Action-Adventure"));

            service.Delete(updated.Genre_id);
            Assert.That(service.ReadAll().ToList().Count, Is.EqualTo(0));
        }
        
        [Test]
        public void PlatformService_CRUD_Works()
        {
            var service = new PlatformService();
            var platform = new Platform("PS5", "Sony", "2020", "9");
            
            service.Create(platform);
            var all = service.ReadAll().ToList();
            Assert.That(all.Count, Is.EqualTo(1));

            var added = all[0];
            added.Manufacturer = "Sony Interactive";
            service.Update(added);
            
            var updated = service.Read(added.Id);
            Assert.That(updated.Manufacturer, Is.EqualTo("Sony Interactive"));

            service.Delete(updated.Id);
            Assert.That(service.ReadAll().ToList().Count, Is.EqualTo(0));
        }

        [Test]
        public void PublisherService_CRUD_Works()
        {
            var service = new PublisherService();
            var pub = new Publisher(0, "EA", "USA", new System.DateTime(1982, 1, 1));
            
            service.Create(pub);
            var all = service.ReadAll().ToList();
            Assert.That(all.Count, Is.EqualTo(1));

            var added = all[0];
            added.Name = "Electronic Arts";
            service.Update(added);
            
            var updated = service.Read(added.Publisher_id);
            Assert.That(updated.Name, Is.EqualTo("Electronic Arts"));

            service.Delete(updated.Publisher_id);
            Assert.That(service.ReadAll().ToList().Count, Is.EqualTo(0));
        }
    }
}
