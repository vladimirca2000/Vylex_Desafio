namespace Vylex.Domain.DTOs;

public class EvaluetionCourseDtoResult
{
    public int Id { get; set; }
    public string Comment { get; set; }
    public int StarEvaluetion { get; set; }
    public DateTime DateTimeEvaluetion { get; set; }

    public int StudentId { get; set; }
    public string StudadeName { get; set; }
}
