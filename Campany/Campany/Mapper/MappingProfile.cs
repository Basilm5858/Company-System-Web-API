using AutoMapper;
using Campany.DTOs;
using Campany.Models;

namespace Campany.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Department, DepartmentDTO>();
            CreateMap<CreateDepartmentDTO, Department>();
            CreateMap<UpdateDepartmentDTO, Department>();

            CreateMap<Employee, EmployeeDTO>();
            CreateMap<CreateEmployeeDTO, Employee>();
            CreateMap<UpdateEmployeeDTO, Employee>();

            CreateMap<Project, ProjectDTO>();
            CreateMap<CreateProjectDTO, Project>();
            CreateMap<UpdateProjectDTO, Project>();

            CreateMap<EmployeeProject, EmployeeProjectDTO>();
            CreateMap<CreateEmployeeProjectDTO, EmployeeProject>();
        }
    }
}
