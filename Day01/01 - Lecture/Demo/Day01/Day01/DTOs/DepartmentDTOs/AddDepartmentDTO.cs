using System.ComponentModel.DataAnnotations;

namespace Day01.DTOs.DepartmentDTOs
{
    public class AddDepartmentDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        //[Required]
        public string? Location { get; set; }

        public int? ManagerId { get; set; }

        public DateOnly? ManagerHiredate { get; set; }

    }
}
