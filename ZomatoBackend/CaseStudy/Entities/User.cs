using System.ComponentModel.DataAnnotations;

namespace CaseStudy.Entities
{
    public class User
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public string UserName { get; set; }
       
        public string? Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Phonenumber { get; set; }
    }

}
