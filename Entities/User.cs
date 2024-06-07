﻿namespace arq_backend.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int RoleId { get; set; }
        public Role Role { get; set; } = null!;
        public ICollection<Subject> Subjects { get; set; } = [];
    }
}
