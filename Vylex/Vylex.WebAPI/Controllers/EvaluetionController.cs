using Microsoft.AspNetCore.Mvc;
using Vylex.Domain.DTOs;
using Vylex.Domain.Interfaces.Services;

namespace Vylex.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EvaluetionController : ControllerBase
{
    private readonly IEvaluetionService _evaluetionService;

    public EvaluetionController(IEvaluetionService evaluetionService)
    {
        _evaluetionService = evaluetionService;
    }

    [HttpGet]
    public async Task<ActionResult> Get()
    {
        var evaluetions = await _evaluetionService.GetEvaluetionsAsync();
        return Ok(evaluetions);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> Get(int id)
    {
        var evaluetion = await _evaluetionService.GetEvaluetionByIdAsync(id);
        return Ok(evaluetion);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] EvaluetionDtoCreate evaluetion)
    {
        await _evaluetionService.AddEvaluetionAsync(evaluetion);
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, [FromBody] EvaluetionDtoUpdate evaluetion)
    {
        await _evaluetionService.UpdateEvaluetionAsync(id, evaluetion);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _evaluetionService.DeleteEvaluetionAsync(id);
        return Ok();
    }

}
