using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_layer
{
	public class Game
	{
		[Key]
		public int Id { get; private set; }

		[Required]
		[MaxLength(60, ErrorMessage = "Title cannot be over 60 symbols!")]
		public string Title { get; private set; }

		[Required]
		public short ReleaseYear { get; private set; }

		[Required]
		public int Studio_id { get; private set; }

		[Required]
		public decimal Price { get; private set; }

		public int Rating { get; private set; }

		[Required]
		[MaxLength(3, ErrorMessage = "The answer should be max 3 words!")]
		public string Multiplayer { get; private set; }

		public short Copies_sold_millions { get; private set; }

		public List<Platform> Platforms { get; private set; }
		public List<Genre> Genres { get; private set; }

		private Game()
		{

		}
		public Game(string title, short releaseYear, int studio_id, decimal price, int rating)
		{
			Title = title;
			ReleaseYear = releaseYear;
			Studio_id = studio_id;
			Price = price;
			Rating = rating;
			Platforms = new List<Platform>();
			Genres = new List<Genre>();
		}
	}
}
