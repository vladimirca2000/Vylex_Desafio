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
        try
        {
            return await _dataset.AnyAsync(e => e.CourseId.Equals(id));
        }
        catch (Exception)
        {
            throw new Exception("Error in the database");
        }
    }

    public async Task<bool> ExistEvaluetionAsync(int courseId, int studentId)
    {
        try
        {
            return await _dataset.AnyAsync(e => e.StudentId.Equals(studentId) && e.CourseId.Equals(courseId));
        }
        catch (Exception)
        {
            throw new Exception("Error in the database");
        }
    }

    public async Task<bool> ExistStudentAsync(int id)
    {
        try
        {
            return await _dataset.AnyAsync(e => e.StudentId.Equals(id));
        }
        catch (Exception)
        {
            throw new Exception("Error in the database");
        }
    }

    public async Task<Evaluetions?> SelectEvaluationCouseStudante(int courseId, int studentId)
    {
        try
        {
            return await _dataset.SingleOrDefaultAsync(e => e.CourseId.Equals(courseId) && e.StudentId.Equals(studentId));
        }
        catch (Exception)
        {
            throw new Exception("Error in the database");
        }
    }
}
