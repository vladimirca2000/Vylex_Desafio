using System.ComponentModel.DataAnnotations;

namespace Vylex.Domain.DTOs;

public class StudentDtoUpdate
{
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "The name of the student is required.")]
    [StringLength(30, MinimumLength = 5, ErrorMessage = "The name of the study must be between 5 and 30 letters")]
    public string StudentName { get; set; }

    [Required(ErrorMessage = "The email of the student is required.")]
    [EmailAddress(ErrorMessage = "The email is invalid.")]
    [StringLength(50, MinimumLength = 5, ErrorMessage = "The e-mail of the study must be between 5 and 50 letters")]
    public string Email { get; set; }
}
