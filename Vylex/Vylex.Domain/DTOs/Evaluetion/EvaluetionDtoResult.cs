namespace Vylex.Domain.DTOs;

public class EvaluetionDtoResult
{
    public int Id { get; set; }
    public string Comment { get; set; }
    public int StarEvaluetion { get; set; }
    public DateTime DateTimeEvaluetion { get; set; }
    public StudentDtoResult Student { get; set; }
    public CourseDtoResult Course { get; set; }
}
