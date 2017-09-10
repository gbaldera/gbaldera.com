using System.ComponentModel.DataAnnotations;

namespace GBaldera.Web.Models
{
    public class Contact
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Url]
        public string Website { get; set; }
        [Required]
        public string Message { get; set; }
    }
}