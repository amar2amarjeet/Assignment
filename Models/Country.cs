using System.ComponentModel.DataAnnotations;

namespace SampleAPI.Models
{
    public class Country
    {
        [Key]
        public string country_code { get; set; }

        public string name { get; set; }
    }
}