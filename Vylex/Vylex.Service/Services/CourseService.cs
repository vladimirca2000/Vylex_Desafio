using AutoMapper;
using System.Net;
using Vylex.Domain.DTOs;
using Vylex.Domain.DTOs.Base;
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

    public async Task<CourseDtoResult?> AddCourseAsync(CourseDtoCreate courseDto)
    {
        if (await _courseRepository.ExistCourseAsync(courseDto.CourseName))
            throw new HttpException(HttpStatusCode.Conflict, "Course already exists");

        var course = _mapper.Map<Courses>(courseDto);
        var result = await _courseRepository.InsertAsync(course);
        if (result == null)
            throw new HttpException(HttpStatusCode.BadRequest, "Student not inserted");

        return _mapper.Map<CourseDtoResult>(result);
    }

    public async Task<CourseDtoResult> UpdateCourseAsync(int id, CourseDtoUpdate course)
    {
        var courseName = await _courseRepository.SelectCourseNomeAsync(course.CourseName);
        if (courseName != null && courseName.Id != course.Id)
            throw new HttpException(HttpStatusCode.Conflict, "Course already exists");        
        
        var courseResult = await _courseRepository.UpdateAsync(id, _mapper.Map<Courses>(course));
        if (courseResult == null)
            throw new HttpException(HttpStatusCode.NotAcceptable, "Course not found, not updated");

        return _mapper.Map<CourseDtoResult>(courseResult);
    }

    public async Task<bool> DeleteCourseAsync(int id)
    {
        var inUseCourse = await _evaluetionRepository.ExistCourseAsync(id);

        if(inUseCourse)
            throw new HttpException(HttpStatusCode.Conflict, "Course cannot be deleted");

        return await _courseRepository.DeleteAsync(id);
    }

    public async Task<CourseDtoResult> GetCourseByIdAsync(int id)
    {
        var courseResult = await _courseRepository.SelectAsync(id);

        if (courseResult == null)
            throw new HttpException(HttpStatusCode.NotFound, "Course not found");

        return _mapper.Map<CourseDtoResult>(courseResult);
    }

    public async Task<IEnumerable<CourseDtoResult>> GetCoursesAsync()
    {
        var listCourseResult = await _courseRepository.SelectAllAsync();
        if (listCourseResult == null)
            throw new HttpException(HttpStatusCode.NotFound, "Courses not found");

        return _mapper.Map<IEnumerable<CourseDtoResult>>(listCourseResult);
    }

    

    
}
