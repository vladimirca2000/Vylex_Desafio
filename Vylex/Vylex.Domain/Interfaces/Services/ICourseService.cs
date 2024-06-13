using Vylex.Domain.DTOs.Course;

namespace Vylex.Domain.Interfaces.Services;

public interface ICourseService
{
    Task<IEnumerable<CourseDtoResult>> GetCoursesAsync();
    Task<CourseDtoResult> GetCourseByIdAsync(int id);
    Task AddCourseAsync(CourseDtoCreate course);
    Task UpdateCourseAsync(int id, CourseDtoUpdate course);
    Task DeleteCourseAsync(int id);

}
