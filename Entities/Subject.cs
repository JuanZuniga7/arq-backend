namespace arq_backend.Entities
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public User Teacher { get; set; } = null!;
        public int TeacherId { get; set; }
        public ICollection<Material> Materials { get; set; } = null!;
    }
}
