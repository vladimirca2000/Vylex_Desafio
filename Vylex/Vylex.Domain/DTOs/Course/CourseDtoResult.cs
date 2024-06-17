using Newtonsoft.Json;

namespace Vylex.Domain.DTOs;

public class CourseDtoResult
{
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("Course Name")]
    public string CourseName { get; set; }

    [JsonProperty("Description")]
    public string Description { get; set; }
}
