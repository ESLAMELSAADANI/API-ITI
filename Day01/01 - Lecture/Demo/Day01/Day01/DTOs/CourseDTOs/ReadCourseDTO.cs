using Day01.Models;
using System.ComponentModel.DataAnnotations;

namespace Day01.DTOs.CourseDTOs
{
    public class ReadCourseDTO
    {
        public int CrsId { get; set; }

        public string CrsName { get; set; }

        public int? CrsDuration { get; set; }

        public int? TopId { get; set; }

        public string? TopicName { get; set; }
    }
}
