using Microsoft.EntityFrameworkCore;
using Vylex.Data.Context;
using Vylex.Domain.Entities;
using Vylex.Domain.Interfaces.Repositories;

namespace Vylex.Data.Repositories;

public class StudentRepository : BaseRepository<Students>, IStudentRepository
{
    private DbSet<Students> _dataset;
    public StudentRepository(ContextoBase context) : base(context)
    {
        _dataset = context.Set<Students>();
    }

    
    public async Task<bool> ExistEmailAsync(string email)
    {
        return await _dataset.AnyAsync(S => S.Email.Equals(email));
    }
}
