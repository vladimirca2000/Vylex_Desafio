using AutoMapper;
using System.Net;
using Vylex.Domain.DTOs;
using Vylex.Domain.DTOs.Base;
using Vylex.Domain.Entities;
using Vylex.Domain.Interfaces.Repositories;
using Vylex.Domain.Interfaces.Services;

namespace Vylex.Service.Services;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _studentRepository;
    private readonly IEvaluetionRepository _evaluetionRepository;
    private readonly IMapper _mapper;

    public StudentService(IStudentRepository studentRepository, IEvaluetionRepository evaluetionRepository, IMapper mapper)
    {        
        _studentRepository = studentRepository;
        _evaluetionRepository = evaluetionRepository;
        _mapper = mapper;
    }

    public async Task<StudentDtoResult> AddStudentAsync(StudentDtoCreate studentDto)
    {   
        if (await _studentRepository.ExistEmailAsync(studentDto.Email))
            throw new HttpException(HttpStatusCode.Conflict, "Student already exists");

        var student = _mapper.Map<Students>(studentDto);
        var result = await _studentRepository.InsertAsync(student);
        if (result == null)
            throw new HttpException(HttpStatusCode.BadRequest, "Student not inserted");

        return _mapper.Map<StudentDtoResult>(result);
    }

    public async Task<StudentDtoResult> UpdateStudentAsync(int id, StudentDtoUpdate studentDto)
    {
        var StudentEmail = await _studentRepository.SelectStudentEmailAsync(studentDto.Email);
        if (StudentEmail != null && StudentEmail.Id != studentDto.Id)
            throw new HttpException(HttpStatusCode.Conflict, "Student already exists");

        var studentResult = await _studentRepository.UpdateAsync(id, _mapper.Map<Students>(studentDto));
        if (studentResult == null)
            throw new HttpException(HttpStatusCode.NotAcceptable, "Student not found, not updated");

        return _mapper.Map<StudentDtoResult>(studentResult);
    }

    public async Task<bool> DeleteStudentAsync(int id)
    {
        var inUseStudent = await _evaluetionRepository.ExistStudentAsync(id);

        if(inUseStudent)
            throw new HttpException(HttpStatusCode.ResetContent, "Student cannot be deleted");

        return await _studentRepository.DeleteAsync(id);
    }

    public async Task<StudentDtoResult> GetStudentByIdAsync(int id)
    {
        var studentResult = await _studentRepository.SelectAsync(id);
        if (studentResult == null)
            throw new HttpException(HttpStatusCode.NotFound, "Student not found");

        return _mapper.Map<StudentDtoResult>(studentResult);
    }

    public async Task<IEnumerable<StudentDtoResult>> GetStudentsAsync()
    {
        var listStudentResult = await _studentRepository.SelectAllAsync();
        if (listStudentResult == null)
            throw new HttpException(HttpStatusCode.NotFound, "Student not found");

        return _mapper.Map<IEnumerable<StudentDtoResult>>(listStudentResult);
    }

    
}

