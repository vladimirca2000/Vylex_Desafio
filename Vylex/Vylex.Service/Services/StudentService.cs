
using Vylex.Domain.DTOs;
using Vylex.Domain.Entities;
using Vylex.Domain.Interfaces.Repositories;
using Vylex.Domain.Interfaces.Services;

namespace Vylex.Service.Services;

public class StudentService : IStudantService
{
    private readonly IRepository<Students> _repository;

    public StudentService(IRepository<Students> repository)
    {
        _repository = repository;
    }

    public Task AddStudentAsync(StudentDtoCreate student)
    {
        throw new NotImplementedException();
    }

    public Task DeleteStudentAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<StudentDtoResult> GetStudentByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<StudentDtoResult>> GetStudentsAsync()
    {
        throw new NotImplementedException();
    }

    public Task UpdateStudentAsync(int id, StudentDtoUpdate student)
    {
        throw new NotImplementedException();
    }
}
