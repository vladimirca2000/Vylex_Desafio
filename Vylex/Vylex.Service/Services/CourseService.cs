using AutoMapper;
using Vylex.Domain.DTOs;
using Vylex.Domain.Entities;
using Vylex.Domain.Interfaces.Repositories;
using Vylex.Domain.Interfaces.Services;

namespace Vylex.Service.Services;

public class CourseService : ICourseService
{
    private readonly IRepository<Courses> _repository;
    private readonly IMapper _mapper;

    public CourseService(IRepository<Courses> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public Task AddCourseAsync(CourseDtoCreate course)
    {
        return _repository.InsertAsync(_mapper.Map<Courses>(course));
    }

    public Task DeleteCourseAsync(int id)
    {
        return _repository.DeleteAsync(id);
    }

    public Task<CourseDtoResult> GetCourseByIdAsync(int id)
    {
        return _repository.SelectAsync(id).ContinueWith(task => _mapper.Map<CourseDtoResult>(task.Result));
    }

    public Task<IEnumerable<CourseDtoResult>> GetCoursesAsync()
    {
        return _repository.SelectAllAsync().ContinueWith(task => _mapper.Map<IEnumerable<CourseDtoResult>>(task.Result));
    }

    public Task UpdateCourseAsync(int id, CourseDtoUpdate course)
    {
        return _repository.UpdateAsync(id, _mapper.Map<Courses>(course));
    }
}
