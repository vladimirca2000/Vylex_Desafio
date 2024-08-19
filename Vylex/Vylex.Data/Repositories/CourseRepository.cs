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

    public async Task<bool> ExistCourseAsync(string courseName)
    {
        try
        {
            return await _dataset.AnyAsync(P => P.CourseName.Equals(courseName));
        }
        catch (Exception)
        {
            throw new Exception("Error in the database");
        }
        
    }

    public async Task<Courses?> SelectCourseNomeAsync(string courseName)
    {
        try
        {
            return await _dataset.SingleOrDefaultAsync(c => c.CourseName.Equals(courseName));
        }
        catch (Exception)
        {
            throw new Exception("Error in the database");
        }
    }
}
