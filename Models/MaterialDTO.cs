namespace arq_backend.Models
{
    public class MaterialDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string DocumentType { get; set; } = null!;
        public string DocumentPath { get; set; } = null!;
        public SubjectDTO Subject { get; set; } = null!;
    }
}
