using System.ComponentModel.DataAnnotations;

namespace Vylex.Domain.DTOs;

public class CourseDtoCreate
{
    [Required(ErrorMessage = "The name of the course is required.")]
    [StringLength(30, MinimumLength = 5, ErrorMessage = "The name of the study must be between 5 and 30 letters")]
    public string CourseName { get; set; }

    [Required(ErrorMessage = "The description of the course is required.")]
    [StringLength(100, MinimumLength = 5, ErrorMessage = "The description of the study must be between 5 and 100 letters")]
    public string Description { get; set; }
}
