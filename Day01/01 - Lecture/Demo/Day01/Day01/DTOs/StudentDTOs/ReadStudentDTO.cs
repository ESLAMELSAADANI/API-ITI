namespace Day01.DTOs.StudentDTOs
{
    public class ReadStudentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }
        public string Address { get; set; }
        public int? DeptId { get; set; }
        public string DeptName { get; set; }
    }
}
