using System.ComponentModel.DataAnnotations;

namespace SampleAPI.Models
{
    public class User
    {
        [Key]
        public int UserId{get;set;}
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string City { get; set; }


    }
}