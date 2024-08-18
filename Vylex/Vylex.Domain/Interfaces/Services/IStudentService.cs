using Vylex.Domain.DTOs;

namespace Vylex.Domain.Interfaces.Services;

public interface IStudentService
{
    Task<IEnumerable<StudentDtoResult>> GetStudentsAsync();
    Task<StudentDtoResult> GetStudentByIdAsync(int id);
    Task<StudentDtoResult> AddStudentAsync(StudentDtoCreate student);
    Task<StudentDtoResult> UpdateStudentAsync(int id, StudentDtoUpdate student);
    Task<bool> DeleteStudentAsync(int id);
}
