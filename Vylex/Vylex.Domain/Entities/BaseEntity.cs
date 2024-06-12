using System.ComponentModel.DataAnnotations;

namespace Vylex.Domain.Entities;

public abstract class BaseEntity
{
    [Key]
    [Required]
    public Guid Id { get; set; }
}
