using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vylex.Domain.DTOs;
using Vylex.Domain.DTOs.Base;
using Vylex.Domain.Interfaces.Services;

namespace Vylex.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class CourseController : ControllerBase
{
    private readonly ICourseService _courseService;

    public CourseController(ICourseService courseService)
    {
        _courseService = courseService;
    }

    /// <summary>
    /// Busca todos os cursos cadastrados no sistema
    /// </summary>
    /// <returns>Lista de CourseDtoResult</returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Get()
    {
        try
        {
            var courses = await _courseService.GetCoursesAsync();
            return Ok(courses);
        }
        catch (HttpException ex)
        {
            return StatusCode((int)ex.StatusCode, ex.Message);
        }

    }

    /// <summary>
    /// Busca o cursos cadastrado no sistema pelo Id
    /// </summary>
    /// <returns>Objeto CourseDtoResult</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Get(int id)
    {
        try
        {
            var course = await _courseService.GetCourseByIdAsync(id);
            return Ok(course);
        }
        catch (HttpException ex)
        {
            return StatusCode((int)ex.StatusCode, ex.Message);
        }

    }

    /// <summary>
    /// Adiciona um cursos no sistema - CourseDtoCreate
    /// </summary>
    /// <returns>Objeto CourseDtoResult</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult> Post([FromBody] CourseDtoCreate course)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _courseService.AddCourseAsync(course);
            return result != null ? Created(string.Empty, result) : BadRequest();
        }
        catch (HttpException ex)
        {
            return StatusCode((int)ex.StatusCode, ex.Message);
        }

    }

    /// <summary>
    /// Atualiza um cursos no sistema - CourseDtoUpdate
    /// </summary>
    /// <returns>Objeto CourseDtoResult</returns>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult> Put(int id, [FromBody] CourseDtoUpdate course)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _courseService.UpdateCourseAsync(id, course);
            return Ok(result);
        }
        catch (HttpException ex)
        {
            return StatusCode((int)ex.StatusCode, ex.Message);
        }

    }

    /// <summary>
    /// Excluir um cursos no sistema - Id
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
            if (await _courseService.DeleteCourseAsync(id))
                return Ok("Course deleted");

            return NotFound("Course not found");
        }
        catch (HttpException ex)
        {
            return StatusCode((int)ex.StatusCode, ex.Message);
        }

    }

    /// <summary>
    /// Busca todos os cursos cadastrados no sistema Com suas Avaliações
    /// </summary>
    /// <returns>Lista de CourseDtoResult</returns>
    [HttpGet, Route("CourseEvaluetion")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> GetCourseEvaluation()
    {
        try
        {
            var coursesEvaluetion = await _courseService.GetCoursesEvaluationAsync();
            return Ok(coursesEvaluetion);
        }
        catch (HttpException ex)
        {
            return StatusCode((int)ex.StatusCode, ex.Message);
        }

    }


}

