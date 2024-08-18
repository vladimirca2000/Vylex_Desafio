using Microsoft.EntityFrameworkCore;
using Vylex.Data.Context;
using Vylex.Domain.Entities;
using Vylex.Domain.Interfaces.Repositories;

namespace Vylex.Data.Repositories;

public class EvaluetionRepository : BaseRepository<Evaluetions>, IEvaluetionRepository
{ 
    private DbSet<Evaluetions> _dataset;
    public EvaluetionRepository(ContextoBase context) : base(context)
    {
        _dataset = context.Set<Evaluetions>();
    }

    public async Task<bool> ExistCourseAsync(int id)
    {
        return await _dataset.AnyAsync(P => P.CourseId.Equals(id));
    }

    public async Task<bool> ExistStudentAsync(int id)
    {
        return await _dataset.AnyAsync(P => P.StudentId.Equals(id));
    }
}
