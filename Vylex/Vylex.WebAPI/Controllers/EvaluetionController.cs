using Microsoft.AspNetCore.Mvc;
using Vylex.Domain.DTOs;
using Vylex.Domain.DTOs.Base;
using Vylex.Domain.Entities;
using Vylex.Domain.Interfaces.Services;
using Vylex.Service.Services;

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


    /// <summary>
    /// Busca todas as Avaliações cadastrados no sistema
    /// </summary>
    /// <returns>Lista de AvaliaçõesDtoResult</returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Get()
    {
        try
        {
            var evaluetions = await _evaluetionService.GetEvaluetionsAsync();
            return Ok(evaluetions);
        }
        catch (HttpException ex)
        {
            return StatusCode((int)ex.StatusCode, ex.Message);
        }
    }

    /// <summary>
    /// Busca a avalição cadastrado no sistema pelo Id
    /// </summary>
    /// <returns>Objeto EvaluetionDtoResult</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Get(int id)
    {
        try
        {
            var evaluetion = await _evaluetionService.GetEvaluetionByIdAsync(id);
            return Ok(evaluetion);
        }
        catch (HttpException ex)
        {
            return StatusCode((int)ex.StatusCode, ex.Message);
        }
    }

    /// <summary>
    /// Adiciona uma avaliação no sistema - EvaluetionDtoCreate
    /// </summary>
    /// <returns>Objeto EvaluetionDtoResult</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult> Post([FromBody] EvaluetionDtoCreate evaluetion)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _evaluetionService.AddEvaluetionAsync(evaluetion);
            return result != null ? Created(string.Empty, result) : BadRequest();
        }
        catch (HttpException ex)
        {
            return StatusCode((int)ex.StatusCode, ex.Message);
        }
    }

    /// <summary>
    /// Atualiza um avaliação no sistema - EvavuetionDtoUpdate
    /// </summary>
    /// <returns>Objeto EvaluetionDtoResult</returns>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult> Put(int id, [FromBody] EvaluetionDtoUpdate evaluetion)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _evaluetionService.UpdateEvaluetionAsync(id, evaluetion);
            return Ok(result);
        }
        catch (HttpException ex)
        {
            return StatusCode((int)ex.StatusCode, ex.Message);
        }
    }

    /// <summary>
    /// Excluir uma avaliação no sistema - Id
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
            if (await _evaluetionService.DeleteEvaluetionAsync(id))
                return Ok("Evaluetion deleted");

            return NotFound("Evaluetion not found");
        }
        catch (HttpException ex)
        {
            return StatusCode((int)ex.StatusCode, ex.Message);
        }
    }

}
