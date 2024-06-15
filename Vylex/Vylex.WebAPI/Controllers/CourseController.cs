using Microsoft.AspNetCore.Mvc;
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
    public async Task<ActionResult> Post([FromBody] CourseDtoCreate course)
    {
        await _courseService.AddCourseAsync(course);
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, [FromBody] CourseDtoUpdate course)
    {
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
