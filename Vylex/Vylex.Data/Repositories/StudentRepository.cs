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
        try
        {
            return await _dataset.AnyAsync(S => S.Email.Equals(email));
        }
        catch (Exception)
        {
            throw new Exception("Error in the database");
        }
    }

    public async Task<Students?> SelectStudentEmailAsync(string email)
    {
        try
        {
            return await _dataset.SingleOrDefaultAsync(s => s.Email.Equals(email));
        }
        catch (Exception)
        {
            throw new Exception("Error in the database");
        }
    }
}
