using Vylex.Domain.Entities;

namespace Vylex.Domain.Interfaces.Repositories;

public interface IEvaluetionRepository : IRepository<Evaluetions>
{
    Task<bool> ExistCourseAsync(int id);
    Task<bool> ExistStudentAsync(int id);
}
