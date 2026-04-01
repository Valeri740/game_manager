using System.ComponentModel.DataAnnotations;

namespace BusinessLayer

{
    public class Publisher
    {
        [Key]
        public int Publisher_id { get; set; }

        [MaxLength(50, ErrorMessage = "The publisher name must be up to 50 characters!")]
        [Required]
        public string Name { get; set; }

        [MaxLength(40, ErrorMessage = "The publisher country must be up to 40 characters!")]
        [Required]
        public string Country { get; set; }

        public DateTime Founded_date { get; set; }

        private Publisher()
        {

        }

        public Publisher(int publisher_id, string name, string country, DateTime founded_date)
        {
            Publisher_id = publisher_id;
            Name = name;
            Country = country;
            Founded_date = founded_date;
        }

    }
}
