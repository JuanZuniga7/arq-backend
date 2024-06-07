using arq_backend.Entities;

namespace arq_backend.Models
{
    public class FullUserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public RoleDTO Role { get; set; } = null!;
        public ICollection<Subject> Subjects { get; set; } = null!;

    }
}
