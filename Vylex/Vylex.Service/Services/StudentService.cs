
using AutoMapper;
using Vylex.Domain.DTOs;
using Vylex.Domain.Entities;
using Vylex.Domain.Interfaces.Repositories;
using Vylex.Domain.Interfaces.Services;

namespace Vylex.Service.Services;

public class StudentService : IStudentService
{
    private readonly IRepository<Students> _repository;
    private readonly IMapper _mapper;

    public StudentService(IRepository<Students> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public Task AddStudentAsync(StudentDtoCreate student)
    {
        return _repository.InsertAsync(_mapper.Map<Students>(student));
    }

    public Task DeleteStudentAsync(int id)
    {
        return _repository.DeleteAsync(id);
    }

    public Task<StudentDtoResult> GetStudentByIdAsync(int id)
    {
        return _repository.SelectAsync(id).ContinueWith(task => _mapper.Map<StudentDtoResult>(task.Result));
    }

    public Task<IEnumerable<StudentDtoResult>> GetStudentsAsync()
    {
        return _repository.SelectAllAsync().ContinueWith(task => _mapper.Map<IEnumerable<StudentDtoResult>>(task.Result));
    }

    public Task UpdateStudentAsync(int id, StudentDtoUpdate student)
    {
        return _repository.UpdateAsync(id, _mapper.Map<Students>(student));
    }
}
