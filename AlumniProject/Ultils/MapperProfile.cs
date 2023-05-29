

using AlumniProject.Dto;
using AlumniProject.Entity;
using AutoMapper;

namespace AlumniProject.Ultils;

public class MapperProfile : Profile
{
	public MapperProfile()
	{
		CreateMap<AlumniDTO, Alumni>().ReverseMap();
        CreateMap<AlumniUpdateDTO, Alumni>().ReverseMap();
        CreateMap<AlumniUpdateDTO, AlumniDTO>().ReverseMap();
        CreateMap<School, SchoolAddDTO>().ReverseMap();
        CreateMap<School, SchoolUpdateDto>().ReverseMap();
        CreateMap<School, SchoolDTO>().ReverseMap();
        CreateMap<Grade, GradeDTO>().ReverseMap();
        CreateMap<Grade, GradeAddDTO>().ReverseMap();
        CreateMap<Grade, GradeUpdateDTO>().ReverseMap();

    }

}
