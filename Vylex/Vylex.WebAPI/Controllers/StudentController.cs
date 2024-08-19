using Microsoft.AspNetCore.Mvc;
using Vylex.Domain.DTOs;
using Vylex.Domain.DTOs.Base;
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

    /// <summary>
    /// Busca todos os Estudantes cadastrados no sistema
    /// </summary>
    /// <returns>Lista de StudentDtoResult</returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Get()
    {
        try
        {
            var students = await _studentService.GetStudentsAsync();
            return Ok(students);
        }
        catch (HttpException ex)
        {
            return StatusCode((int)ex.StatusCode, ex.Message);
        }

    }

    /// <summary>
    /// Busca o estudantes cadastrado no sistema pelo Id
    /// </summary>
    /// <returns>Objeto StudentDtoResult</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Get(int id)
    {
        try
        {
            var student = await _studentService.GetStudentByIdAsync(id);
            return Ok(student);
        }
        catch (HttpException ex)
        {
            return StatusCode((int)ex.StatusCode, ex.Message);
        }
    }

    /// <summary>
    /// Adiciona um estudante no sistema - StudentDtoCreate
    /// </summary>
    /// <returns>Objeto StudentDtoResult</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult> Post([FromBody] StudentDtoCreate student)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _studentService.AddStudentAsync(student);
            return result != null ? Created(string.Empty, result) : BadRequest();
        }
        catch (HttpException ex)
        {
            return StatusCode((int)ex.StatusCode, ex.Message);
        }        
    }

    /// <summary>
    /// Atualiza um estudante no sistema - StudentDtoUpdate
    /// </summary>
    /// <returns>Objeto StudentDtoResult</returns>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult> Put(int id, [FromBody] StudentDtoUpdate student)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _studentService.UpdateStudentAsync(id, student);
            return Ok(result);
        }
        catch (HttpException ex)
        {
            return StatusCode((int)ex.StatusCode, ex.Message);
        }
    }

    /// <summary>
    /// Excluir um estudante no sistema - Id
    /// </summary>
    /// <returns>String</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult> Delete(int id)
    {
        try
        {
            if (await _studentService.DeleteStudentAsync(id))
                return Ok("Student deleted");

            return NotFound("Student not found");
        }
        catch (HttpException ex)
        {
            return StatusCode((int)ex.StatusCode, ex.Message);
        }
    }
}

