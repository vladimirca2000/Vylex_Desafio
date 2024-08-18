using AutoMapper;
using Vylex.Domain.DTOs;
using Vylex.Domain.Entities;

namespace Vylex.CrossCutting.Mappings;

public class EntityToDtoProfile : Profile
{
    public EntityToDtoProfile()
    {
        #region Course

        CreateMap<CourseDtoResult, Courses>().ReverseMap();

        CreateMap<CourseDtoCreate, Courses>().ReverseMap();

        CreateMap<CourseDtoUpdate, Courses>().ReverseMap();

        #endregion

        #region Student

        CreateMap<StudentDtoResult, Students>().ReverseMap();

        CreateMap<StudentDtoCreate, Students>().ReverseMap();

        CreateMap<StudentDtoUpdate, Students>().ReverseMap();

        #endregion

        #region Evaluetion

        CreateMap<EvaluetionDtoResult, Evaluetions>().ReverseMap();

        CreateMap<EvaluetionDtoCreate, Evaluetions>().ReverseMap();

        CreateMap<EvaluetionDtoUpdate, Evaluetions>().ReverseMap();

        #endregion
    }
}
