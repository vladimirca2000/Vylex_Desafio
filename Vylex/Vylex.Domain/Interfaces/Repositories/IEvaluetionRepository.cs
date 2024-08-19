using Vylex.Domain.Entities;

namespace Vylex.Domain.Interfaces.Repositories;

public interface IEvaluetionRepository : IRepository<Evaluetions>
{
    Task<bool> ExistCourseAsync(int id);
    Task<bool> ExistStudentAsync(int id);
    Task<bool> ExistEvaluetionAsync(int courseId, int studentId);
    Task<Evaluetions?> SelectEvaluationCouseStudante(int courseId, int studentId);
}
