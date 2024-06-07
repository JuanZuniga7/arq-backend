using System.ComponentModel.DataAnnotations;

namespace arq_backend.Models
{
    public class CreateUser
    {
        [Required]
        public string FirstName { get; set; } = null!;
        [Required]
        public string LastName { get; set; } = null!;
        [Required]
        public string Email { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
        [Required]
        public int RoleId { get; set; }
    }
}
