using Vylex.Domain.DTOs;

namespace Vylex.Domain.Interfaces.Services;

public interface ICourseService
{
    Task<IEnumerable<CourseDtoResult>> GetCoursesAsync();
    Task<CourseDtoResult> GetCourseByIdAsync(int id);
    Task<CourseDtoResult> AddCourseAsync(CourseDtoCreate course);
    Task<CourseDtoResult> UpdateCourseAsync(int id, CourseDtoUpdate course);
    Task<bool> DeleteCourseAsync(int id);

}
