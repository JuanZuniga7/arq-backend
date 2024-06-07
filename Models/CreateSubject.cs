namespace arq_backend.Models
{
    public class CreateSubject
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; } = null!;
        public int TeacherId { get; set; }
    }
}
