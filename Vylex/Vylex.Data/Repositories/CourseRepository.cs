using Microsoft.EntityFrameworkCore;
using Vylex.Data.Context;
using Vylex.Domain.Entities;
using Vylex.Domain.Interfaces.Repositories;

namespace Vylex.Data.Repositories;

public class CourseRepository : BaseRepository<Courses>, ICourseRepositoty
{
    private DbSet<Courses> _dataset;
    public CourseRepository(ContextoBase context) : base(context)
    {
        _dataset = context.Set<Courses>();
    }
}
