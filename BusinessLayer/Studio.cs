using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
	public class Studio
	{
		[Key]

		public int Studio_id { get; private set; }

		[Required]
		[MaxLength(50)]

		public string Name { get; private set; }

		[Required]
		[MaxLength(40)]
		public string Country { get; private set; }

		[Required]
		public string Founded_date { get; private set; }

		[Required]
		public string Website { get; private set; }

		public List<Game> Games { get;  set; }

		private Studio()
		{

		}

		public Studio(string name, string country, string founded_date, string website) : this()
		{
			this.Name = name;
			this.Country = country;
			this.Founded_date = founded_date;
			this.Website = website;
		}

	}
}

