using AutoMapper;
using Day01.DTOs.CourseDTOs;
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
                dest.DeptId = src.DeptId ?? 0;
                dest.DeptName = src.Dept?.DeptName ?? "No Dept!";
                dest.SuperVisorId = src.StSuper ?? 0;
                dest.SupervisorName = $"{src.StSuperNavigation?.StFname ?? " "} {src.StSuperNavigation?.StLname ?? " "}".Trim();
            }).ReverseMap();

            CreateMap<AddStudentDTO, Student>().AfterMap((src, dest) =>
            {
                dest.StId = src.Id;
                dest.StFname = src.Name;
                dest.StAddress = src.Address ?? "Mansoura";
                dest.StAge = src.Age ?? 0;
                dest.StSuper = src.SupervisorId ?? 0;
            }).ReverseMap();

            CreateMap<Department, ReadDepartmentDTO>().AfterMap((src, dest) =>
            {
                dest.Id = src.DeptId;
                dest.Name = src.DeptName ?? "";
                dest.Location = src.DeptLocation ?? "";
                dest.MgrId = src.DeptManager ?? 0;
                dest.MgrName = src.DeptManagerNavigation?.InsName ?? "";
                dest.StudentNo = src.Students?.Count();
                dest.StudentNames = src.Students?.Select((s, i) => $"{i + 1} - {s.StFname} {s.StLname}".Trim()).ToList() ?? new List<string>();
            }).ReverseMap();

            CreateMap<AddDepartmentDTO, Department>().AfterMap((src, dest) =>
            {
                dest.DeptId = src.Id;
                dest.DeptName = src.Name;
                dest.DeptLocation = src.Location ?? null;
                dest.DeptManager = src.ManagerId ?? null;
                dest.ManagerHiredate = src.ManagerHiredate ?? DateOnly.FromDateTime(DateTime.Now);
            }).ReverseMap();

            CreateMap<Course, ReadCourseDTO>()
                .AfterMap((src, dest) =>
                {
                    dest.TopId = src.TopId;
                    dest.CrsName = src.CrsName ?? "";
                    dest.CrsDuration = src.CrsDuration ?? 0;
                    dest.TopId = src.TopId ?? 0;
                    dest.TopicName = src.Top?.TopName ?? "No Topic!";
                })
                .ReverseMap();
            CreateMap<AddCourseDTO, Course>().ReverseMap();
        }

    }
}
