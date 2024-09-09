using AutoMapper;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.ViewModel;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Student, StudentViewModel>().ReverseMap();
        CreateMap<Teacher, TeacherViewModel>().ReverseMap();


    }
}
