using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vylex.Domain.Entities;

public class Evaluetions : BaseEntity
{
    [Required(ErrorMessage = "Course evaluetion date and time is required.")]
    [Display(Name = "Date and Time of the Course Evaluetion")]
    public DateTime DateTimeEvaluetion { get; init; } = DateTime.Now;

    [Required(ErrorMessage = "The course evaluetion star is required.")]
    [Display(Name = "Course Evaluetion Star")]
    [Range(1, 5, ErrorMessage = "The course evaluetion star must be between 1 and 5.")]
    public int StarEvaluetion { get; private set; } = 1;

    [Display(Name = "Course Evaluetion Comment")]
    public string Comment { get; private set; }

    [Required]
    [ForeignKey("StudentId")]
    public Guid StudentId { get; private set; }
    public Students Student { get; private set; }

    [Required]
    [ForeignKey("CourseId")]
    public Guid CourseId { get; private set; }
    public Courses Course { get; private set; }

}
