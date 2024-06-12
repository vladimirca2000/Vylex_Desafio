using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vylex.Domain.Entities;

namespace Vylex.Data.Mapping;

public class EvaluetionMap : IEntityTypeConfiguration<Evaluetions>
{
    public void Configure(EntityTypeBuilder<Evaluetions> builder)
    {
        throw new NotImplementedException();
    }
}
