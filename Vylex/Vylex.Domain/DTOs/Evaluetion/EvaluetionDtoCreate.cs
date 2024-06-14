using System.ComponentModel.DataAnnotations;

namespace Vylex.Domain.DTOs;

public class EvaluetionDtoCreate
{
    public string Comment { get; set; }

    [Required(ErrorMessage = "The evaluation is required.")]
    [Range(1, 5, ErrorMessage = "The evaluation must be between 1 and 5 stars.")]
    public int StarEvaluetion { get; set; }

    [Required(ErrorMessage = "The date of the evaluation is required.")]
    public DateTime DateTimeEvaluetion { get; set; }

    [Required(ErrorMessage = "The student id is required.")]
    public int StudentId { get; set; }

    [Required(ErrorMessage = "The course id is required.")]
    public int CourseId { get; set; }
}
