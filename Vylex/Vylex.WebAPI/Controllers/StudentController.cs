using Microsoft.AspNetCore.Mvc;
using Vylex.Domain.DTOs;
using Vylex.Domain.Interfaces.Services;

namespace Vylex.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentController : ControllerBase
{
    private readonly IStudentService _studentService;

    public StudentController(IStudentService studentService)
    {
        _studentService = studentService;
    }

    [HttpGet]
    public async Task<ActionResult> Get()
    {
        var students = await _studentService.GetStudentsAsync();
        return Ok(students);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> Get(int id)
    {
        var student = await _studentService.GetStudentByIdAsync(id);
        return Ok(student);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Post([FromBody] StudentDtoCreate student)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _studentService.AddStudentAsync(student);
        return result != null ? Created(string.Empty, result) : BadRequest();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, [FromBody] StudentDtoUpdate student)
    {
        await _studentService.UpdateStudentAsync(id, student);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var result = await _studentService.DeleteStudentAsync(id);
        if (!result)
            return NotFound();

        return Ok();
    }
}
