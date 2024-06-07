namespace arq_backend.Models
{
    public class CreateMaterial
    {
        public string Name { get; set; }= null!;
        public string Description { get; set; } = null!;
        public string DocumentType { get; set; } = null!;
        public string DocumentPath { get; set; } = null!;
        public int SubjectId { get; set; }
    }
}
