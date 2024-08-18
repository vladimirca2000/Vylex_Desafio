using Vylex.Domain.Entities;

namespace Vylex.Domain.Interfaces.Repositories;

public interface IRepository<T> where T : BaseEntity
{
    Task<T?> InsertAsync(T item);
    Task<T?> UpdateAsync(int id, T item);
    Task<bool> DeleteAsync(int id);
    Task<T?> SelectAsync(int id);
    Task<IEnumerable<T>> SelectAllAsync();
    Task<bool> ExistAsync(int id);
}
