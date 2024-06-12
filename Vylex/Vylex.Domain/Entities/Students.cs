using System.ComponentModel.DataAnnotations;

namespace Vylex.Domain.Entities;

public class Students : BaseEntity
{
    [Required(ErrorMessage = "The name of the study is required.")]
    [Display(Name = "Student Name")]
    [StringLength(50, MinimumLength = 5, ErrorMessage = "The name of the study must be between 5 and 50 letters")]
    public string StudentName { get; private set; }

    [Required(ErrorMessage = "The email is required.")]
    [Display(Name = "Student Email")]
    [EmailAddress(ErrorMessage = "The email is invalid.")]
    [StringLength(50, MinimumLength = 5, ErrorMessage = "The email must be between 5 and 50 letters")]
    public string Email { get; private set; }
}
