﻿using Vylex.Domain.DTOs;
using Vylex.Domain.Entities;
using Vylex.Domain.Interfaces.Repositories;
using Vylex.Domain.Interfaces.Services;

namespace Vylex.Service.Services;

public class CourseService : ICourseService
{
    private readonly IRepository<Courses> _repository;
    public CourseService(IRepository<Courses> repository)
    {
        _repository = repository;
    }

    public Task AddCourseAsync(CourseDtoCreate course)
    {
        throw new NotImplementedException();
    }

    public Task DeleteCourseAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<CourseDtoResult> GetCourseByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<CourseDtoResult>> GetCoursesAsync()
    {
        throw new NotImplementedException();
    }

    public Task UpdateCourseAsync(int id, CourseDtoUpdate course)
    {
        throw new NotImplementedException();
    }
}
