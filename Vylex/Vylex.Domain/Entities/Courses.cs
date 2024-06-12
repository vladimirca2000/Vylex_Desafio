using System.ComponentModel.DataAnnotations;

namespace Vylex.Domain.Entities;

public class Courses : BaseEntity
{
    [Required(ErrorMessage = "The name of the course is required.")]
    [Display(Name = "Course Name")]
    [StringLength(30, MinimumLength = 5, ErrorMessage = "The name of the study must be between 5 and 30 letters")]
    public string CourseName { get; set; }

    [Required(ErrorMessage = "The description of the course is required.")]
    [Display(Name = "Course Description")]
    [StringLength(100, MinimumLength = 5, ErrorMessage = "The description of the study must be between 5 and 100 letters")]
    public string Description { get; set; }
}
