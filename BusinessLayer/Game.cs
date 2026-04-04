using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
namespace BusinessLayer
{
	public class Game
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(60, ErrorMessage = "Title cannot be over 60 symbols!")]
		public string Title { get; set; }

		[Required]
		public short ReleaseYear { get; set; }

		[Required]
		[ForeignKey(nameof(Studio))]
		public int Studio_id { get; set; }
		
		public virtual Studio Studio { get; set; }

		[Required]
		public decimal Price { get; set; }

		public int Rating { get; set; }

		[Required]
		[MaxLength(3, ErrorMessage = "The answer should be max 3 words!")]
		public string Multiplayer { get; set; }

		public short Copies_sold_millions { get; set; }

		public List<Platform> Platforms { get;  set; }
		public List<Genre> Genres { get;  set; }

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
