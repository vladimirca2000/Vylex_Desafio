using AutoMapper;
using Vylex.Domain.DTOs.Course;
using Vylex.Domain.Entities;

namespace Vylex.CrossCutting.Mappings;

public class EntityToDtoProfile : Profile
{
    public EntityToDtoProfile()
    {
        #region Course

        CreateMap<CourseDtoResult, Courses>()
                .ReverseMap();

        CreateMap<CourseDtoCreate, Courses>()
            .ReverseMap();

        CreateMap<CourseDtoUpdate, Courses>()
            .ReverseMap();

        #endregion
    }
}
