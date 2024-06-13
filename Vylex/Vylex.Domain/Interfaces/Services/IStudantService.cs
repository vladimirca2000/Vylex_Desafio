using Vylex.Domain.DTOs;

namespace Vylex.Domain.Interfaces.Services;

public interface IStudantService
{
    Task<IEnumerable<StudentDtoResult>> GetStudentsAsync();
    Task<StudentDtoResult> GetStudentByIdAsync(int id);
    Task AddStudentAsync(StudentDtoCreate student);
    Task UpdateStudentAsync(int id, StudentDtoUpdate student);
    Task DeleteStudentAsync(int id);
}
