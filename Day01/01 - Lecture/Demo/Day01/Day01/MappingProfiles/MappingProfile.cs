using AutoMapper;
using Day01.DTOs.DepartmentDTOs;
using Day01.DTOs.StudentDTOs;
using Day01.Models;

namespace Day01.MappingProfiles
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Student, ReadStudentDTO>().AfterMap((src, dest) =>
			{
				dest.Id = src.StId;
				dest.Name = $"{src.StFname} {src.StLname}".Trim();
				dest.Address = src.StAddress ?? " ";
				dest.Age = src.StAge ?? 0;
				dest.DeptName = src.Dept?.DeptName ?? "No Dept!";
			}).ReverseMap();

			CreateMap<AddStudentDTO, Student>().AfterMap((src, dest) =>
			{
				dest.StId = src.Id;
				dest.StFname = src.Name;
				dest.StAddress = src.Address ?? "Mansoura";
				dest.StAge = src.Age ?? 0;
			}).ReverseMap();

			CreateMap<Department, ReadDepartmentDTO>().AfterMap((src, dest) =>
			{
				dest.Id = src.DeptId;
				dest.Name = src.DeptName ?? "";
				dest.Location = src.DeptLocation ?? "";
				dest.StudentNo = src.Students?.Count();
				dest.StudentNames = src.Students?.Select((s, i) => $"{i + 1} - {s.StFname} {s.StLname}".Trim()).ToList() ?? new List<string>();
			}).ReverseMap();

		}

	}
}
