using Microsoft.AspNetCore.Mvc;
using System.Net;
using Vylex.Domain.DTOs;
using Vylex.Domain.Interfaces.Services;

namespace Vylex.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
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
    /// <returns>Lista de CursoDtoResult</returns>
    [HttpGet]
    public async Task<ActionResult> Get()
    {
        var courses = await _courseService.GetCoursesAsync();
        return Ok(courses);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> Get(int id)
    {
        var course = await _courseService.GetCourseByIdAsync(id);
        return Ok(course);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Post([FromBody] CourseDtoCreate course)
    {
        if(ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _courseService.AddCourseAsync(course);
        return result != null ? Created(string.Empty, result) : BadRequest();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, [FromBody] CourseDtoUpdate course)
    {
        if(ModelState.IsValid)
            return BadRequest(ModelState);

        await _courseService.UpdateCourseAsync(id, course);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _courseService.DeleteCourseAsync(id);
        return Ok();
    }
}
