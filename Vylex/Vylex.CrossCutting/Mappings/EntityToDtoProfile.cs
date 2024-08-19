using AutoMapper;
using Vylex.Domain.DTOs;
using Vylex.Domain.Entities;

namespace Vylex.CrossCutting.Mappings;

public class EntityToDtoProfile : Profile
{
    public EntityToDtoProfile()
    {
        #region Course

        CreateMap<Courses, CourseDtoResult>().ReverseMap();

        CreateMap<Courses, CourseDtoCreate>().ReverseMap();

        CreateMap<Courses, CourseDtoUpdate>().ReverseMap();

        CreateMap<Courses, CourseEvaluationDtoResult>()
            .ForMember(d => d.ListEvaluations, o => o.MapFrom(s => s.ListEvaluetions))
            .ReverseMap();

        #endregion

            #region Student

        CreateMap<Students, StudentDtoResult>().ReverseMap();

        CreateMap<Students, StudentDtoCreate>().ReverseMap();

        CreateMap<Students, StudentDtoUpdate>().ReverseMap();

        #endregion

        #region Evaluetion

        CreateMap<Evaluetions, EvaluetionDtoResult>().ReverseMap();

        CreateMap<Evaluetions, EvaluetionDtoCreate>().ReverseMap();

        CreateMap<Evaluetions, EvaluetionDtoUpdate>().ReverseMap();

        CreateMap<Evaluetions, EvaluetionCourseDtoResult>()
            .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
            .ForMember(d => d.Comment, o => o.MapFrom(s => s.Comment))
            .ForMember(d => d.StarEvaluetion, o => o.MapFrom(s => s.StarEvaluetion))
            .ForMember(d => d.DateTimeEvaluetion, o => o.MapFrom(s => s.DateTimeEvaluetion))
            .ForMember(d => d.StudentId, o => o.MapFrom(s => s.StudentId))
            .ForMember(d => d.StudadeName, o => o.MapFrom(s => s.Student.StudentName))
            .ReverseMap();

        #endregion
    }
}
