using System.ComponentModel.DataAnnotations;

namespace Day01.DTOs.CourseDTOs
{
    public class AddCourseDTO
    {
        public int CrsId { get; set; }
        [Required]
        public string CrsName { get; set; }

        public int? CrsDuration { get; set; }

        public int? TopId { get; set; }
    }
}
