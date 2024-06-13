using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vylex.Domain.DTOs.Course;
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

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var courses = await _courseService.GetCoursesAsync();
        return Ok(courses);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var course = await _courseService.GetCourseByIdAsync(id);
        return Ok(course);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CourseDtoCreate course)
    {
        await _courseService.AddCourseAsync(course);
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] CourseDtoUpdate course)
    {
        await _courseService.UpdateCourseAsync(id, course);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _courseService.DeleteCourseAsync(id);
        return Ok();
    }
}
