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
}
