using AutoMapper;
using SynetecAssessment.Domain;
using SynetecAssessmentApi.Dtos;

namespace SynetecAssessment.Api.Services.Mapper
{
	public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Department, DepartmentDto>()
               .ForMember(dd => dd.Description, opt => opt.MapFrom(d => d.Description))
               .ForMember(dd => dd.Title, opt => opt.MapFrom(d => d.Title));

            CreateMap<Employee, EmployeeDto>()
                .ForMember(ed => ed.Fullname, opt => opt.MapFrom(e => e.Fullname))
                .ForMember(ed => ed.Department, opt => opt.MapFrom(e => e.Department))
                .ForMember(ed => ed.JobTitle, opt => opt.MapFrom(e => e.JobTitle))
                .ForMember(ed => ed.Salary, opt => opt.MapFrom(e => e.Salary));
        }
    }
}
