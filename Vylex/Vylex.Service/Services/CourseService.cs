using AutoMapper;
using System.Net;
using System.Net.Mail;
using Vylex.Domain.Common;
using Vylex.Domain.DTOs;
using Vylex.Domain.Entities;
using Vylex.Domain.Interfaces.Repositories;
using Vylex.Domain.Interfaces.Services;

namespace Vylex.Service.Services;

public class CourseService : ICourseService
{
    private readonly ICourseRepositoty _courseRepository;
    private readonly IEvaluetionRepository _evaluetionRepository;
    private readonly IMapper _mapper;

    public CourseService(ICourseRepositoty courseRepository, IEvaluetionRepository evaluetionRepository, IMapper mapper)
    {
        _courseRepository = courseRepository;
        _evaluetionRepository = evaluetionRepository;
        _mapper = mapper;
    }

    public Task AddCourseAsync(CourseDtoCreate course)
    {
        return _courseRepository.InsertAsync(_mapper.Map<Courses>(course));
    }

    public async Task<bool> DeleteCourseAsync(int id)
    {
        var testeCourse = await _evaluetionRepository.ExistCourseAsync(id);
        var testeStudent = await _evaluetionRepository.ExistStudentAsync(id);

        if(testeCourse)
        {
            throw new HttpException(HttpStatusCode.ResetContent, "Course has evaluations");
        }

        if(testeStudent)
        {
            throw new HttpException(HttpStatusCode.ResetContent, "Student has evaluations");
        }

        var result = await _courseRepository.DeleteAsync(id);
        
        return result;
    }

    public Task<CourseDtoResult> GetCourseByIdAsync(int id)
    {
        return _courseRepository.SelectAsync(id).ContinueWith(task => _mapper.Map<CourseDtoResult>(task.Result));
    }

    public Task<IEnumerable<CourseDtoResult>> GetCoursesAsync()
    {
        return _courseRepository.SelectAllAsync().ContinueWith(task => _mapper.Map<IEnumerable<CourseDtoResult>>(task.Result));
    }

    public Task UpdateCourseAsync(int id, CourseDtoUpdate course)
    {
        return _courseRepository.UpdateAsync(id, _mapper.Map<Courses>(course));
    }
}
