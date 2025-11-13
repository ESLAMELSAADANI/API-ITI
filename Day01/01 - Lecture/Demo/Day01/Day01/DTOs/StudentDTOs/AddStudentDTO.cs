using System.ComponentModel.DataAnnotations;

namespace Day01.DTOs.StudentDTOs
{
    public class AddStudentDTO
    {
        [Required]
        public int Id { get; set; }
        [Required,StringLength(50)]
        public string Name { get; set; }
        public int? Age { get; set; }
        public string Address { get; set; }
        public int? DeptId { get; set; }
        public int? SupervisorId { get; set; }
    }
}
