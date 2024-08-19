using Vylex.Domain.Entities;

namespace Vylex.Domain.Interfaces.Repositories;

public interface ICourseRepositoty : IRepository<Courses>
{
    Task<bool> ExistCourseAsync(string courseName);
    Task<Courses?> SelectCourseNomeAsync(string courseName);

}
