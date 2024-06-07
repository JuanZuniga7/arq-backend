namespace arq_backend.Models
{
    public class SubjectDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int TeacherId { get; set; }
        public string TeacherName { get; set; } = null!;
        public ICollection<MaterialDTO> Materials { get; set; } = null!;
    }
}
