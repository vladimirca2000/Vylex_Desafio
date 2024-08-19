using Vylex.Domain.Entities;

namespace Vylex.Domain.Interfaces.Repositories;

public interface IStudentRepository : IRepository<Students>
{
    Task<bool> ExistEmailAsync(string email);
    Task<Students?> SelectStudentEmailAsync(string email);
}
