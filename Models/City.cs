using System.ComponentModel.DataAnnotations;

namespace SampleAPI.Models
{
    public class City
    {

        [Key]
        public string city_code { get; set; }
        public string name { get; set; }

        public string country_code { get; set; }

        public string state_code { get; set; }
    }
}