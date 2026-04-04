using NUnit.Framework;
using BusinessLayer;

namespace TestingLayer
{
    [TestFixture]
    public class BusinessLayerTests
    {
        [Test]
        public void Game_Constructor_InitializesProperties()
        {
            var game = new Game("Cyberpunk 2077", 2020, 1, 59.99m, 9);
            Assert.That(game.Title, Is.EqualTo("Cyberpunk 2077"));
            Assert.That(game.ReleaseYear, Is.EqualTo((short)2020));
            Assert.That(game.Studio_id, Is.EqualTo(1));
            Assert.That(game.Price, Is.EqualTo(59.99m));
            Assert.That(game.Rating, Is.EqualTo(9));
            Assert.That(game.Genres, Is.Not.Null);
            Assert.That(game.Platforms, Is.Not.Null);
        }

        [Test]
        public void Studio_Constructor_InitializesProperties()
        {
            var studio = new Studio("CD Projekt Red", "Poland", "1994", "cdprojekt.com");
            Assert.That(studio.Name, Is.EqualTo("CD Projekt Red"));
            Assert.That(studio.Country, Is.EqualTo("Poland"));
            Assert.That(studio.Founded_date, Is.EqualTo("1994"));
            Assert.That(studio.Website, Is.EqualTo("cdprojekt.com"));
        }

        [Test]
        public void Genre_Constructor_InitializesProperties()
        {
            var genre = new Genre(1, "RPG", "Role-playing game", new System.Collections.Generic.List<Game>());
            Assert.That(genre.Genre_id, Is.EqualTo(1));
            Assert.That(genre.Name, Is.EqualTo("RPG"));
            Assert.That(genre.Description, Is.EqualTo("Role-playing game"));
            Assert.That(genre.Games, Is.Not.Null);
        }

        [Test]
        public void Platform_Constructor_InitializesProperties()
        {
            var platform = new Platform("PC", "Various", "1980", "1");
            Assert.That(platform.Name, Is.EqualTo("PC"));
            Assert.That(platform.Manufacturer, Is.EqualTo("Various"));
            Assert.That(platform.Release_date, Is.EqualTo("1980"));
            Assert.That(platform.Generation, Is.EqualTo("1"));
        }

        [Test]
        public void Publisher_Constructor_InitializesProperties()
        {
            var date = new System.DateTime(1994, 1, 1);
            var publisher = new Publisher(1, "CD Projekt", "Poland", date);
            Assert.That(publisher.Publisher_id, Is.EqualTo(1));
            Assert.That(publisher.Name, Is.EqualTo("CD Projekt"));
            Assert.That(publisher.Country, Is.EqualTo("Poland"));
            Assert.That(publisher.Founded_date, Is.EqualTo(date));
        }
    }
}
