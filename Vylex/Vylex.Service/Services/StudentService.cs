
using AutoMapper;
using System.Net;
using Vylex.Domain.Common;
using Vylex.Domain.DTOs;
using Vylex.Domain.Entities;
using Vylex.Domain.Interfaces.Repositories;
using Vylex.Domain.Interfaces.Services;

namespace Vylex.Service.Services;

public class StudentService : IStudentService
{
    private readonly IRepository<Students> _repository;
    private readonly IEvaluetionRepository _evaluetionRepository;
    private readonly IMapper _mapper;

    public StudentService(IRepository<Students> repository, IEvaluetionRepository evaluetionRepository, IMapper mapper)
    {
        _repository = repository;
        _evaluetionRepository = evaluetionRepository;
        _mapper = mapper;
    }

    public async Task<StudentDtoResult> AddStudentAsync(StudentDtoCreate student)
    {
        var studentResult = _mapper.Map<Students>(student);
        var result = await _repository.InsertAsync(studentResult);
        if (result == null)
        {
            throw new HttpException(HttpStatusCode.BadRequest, "Student not inserted");
        }
        return _mapper.Map<StudentDtoResult>(result);
    }

    public async Task<bool> DeleteStudentAsync(int id)
    {
        var testeStudent = await _evaluetionRepository.ExistStudentAsync(id);
        if(testeStudent)
        {
            throw new HttpException(HttpStatusCode.ResetContent, "Student has evaluations");
        }
        return await _repository.DeleteAsync(id);
    }

    public async Task<StudentDtoResult> GetStudentByIdAsync(int id)
    {
        var studentResult = await _repository.SelectAsync(id);
        if (studentResult == null)
        {
            throw new HttpException(HttpStatusCode.NotFound, "Student not found");
        }
        return _mapper.Map<StudentDtoResult>(studentResult);
    }

    public async Task<IEnumerable<StudentDtoResult>> GetStudentsAsync()
    {
        var listStudentResult = await _repository.SelectAllAsync();
        if (listStudentResult == null)
        {
            throw new HttpException(HttpStatusCode.NotFound, "Student not found");
        }
        return _mapper.Map<IEnumerable<StudentDtoResult>>(listStudentResult);
    }

    public async Task<StudentDtoResult> UpdateStudentAsync(int id, StudentDtoUpdate student)
    {
        var studentResult = await _repository.SelectAsync(id);
        if (studentResult == null)
        {
            throw new HttpException(HttpStatusCode.NotFound, "Student not found");
        }
        return _mapper.Map<StudentDtoResult>(studentResult);
    }
}
