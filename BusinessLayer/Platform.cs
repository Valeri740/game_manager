using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
	public class Platform
	{
		[Key]

		public int Id { get; private set; }
		
		[Required]
		[MaxLength(50)]
		
		public string Name { get; private set; }
		
		[Required]
		[MaxLength(40)]
		public string Manufacturer { get; private set; }
		
		[Required]
		public string Release_date { get; private set; }
		
		[Required]
		public string Generation { get; private set; }
		
		
		
		
		
		public List<Game> Games { get;  set; }
		
		private Platform()
		{
			
		}
		
		public Platform(string name, string manufacturer, string release_date, string generation) : this()
		{
			this.Name = name;
			this.Manufacturer = manufacturer;
			this.Release_date = release_date;
			this.Generation = generation;
		}
	}
}


