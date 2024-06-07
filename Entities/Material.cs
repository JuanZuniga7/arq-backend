namespace arq_backend.Entities
{
    public class Material
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string DocumentType { get; set; } = null!;
    }
}
