using Day01.Models;

namespace Day01.DTOs.DepartmentDTOs
{
	public class ReadDepartmentDTO
	{

		public int Id { get; set; }

		public string Name { get; set; }

		public string Location { get; set; }

		public int? StudentNo { get; set; }

		public IEnumerable<string> StudentNames { get; set; } = new List<String>();
	}
}

