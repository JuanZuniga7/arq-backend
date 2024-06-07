namespace arq_backend.Models
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public int RoleId { get; set; }
        public string Token { get; set; } = null!;
    }
}
