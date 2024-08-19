using AutoMapper;
using System.Net;
using Vylex.Data.Repositories;
using Vylex.Domain.DTOs;
using Vylex.Domain.DTOs.Base;
using Vylex.Domain.Entities;
using Vylex.Domain.Interfaces.Repositories;
using Vylex.Domain.Interfaces.Services;

namespace Vylex.Service.Services;

public class EvaluetionService : IEvaluetionService
{
    private readonly IEvaluetionRepository _evaluetionRepository;
    private readonly IMapper _mapper;
    public EvaluetionService(IEvaluetionRepository evaluetionRepository, IMapper mapper)
    {
        _evaluetionRepository = evaluetionRepository;
        _mapper = mapper;
    }

    public async Task<EvaluetionDtoResult> AddEvaluetionAsync(EvaluetionDtoCreate evaluetionDto)
    {
        if (await _evaluetionRepository.ExistEvaluetionAsync(evaluetionDto.CourseId, evaluetionDto.StudentId))
            throw new HttpException(HttpStatusCode.Conflict, "Evaluation already exists");

        var EvaluetionResult = _mapper.Map<Evaluetions>(evaluetionDto);
        var result = await _evaluetionRepository.InsertAsync(EvaluetionResult);
        if (result == null)
            throw new HttpException(HttpStatusCode.BadRequest, "Evaluation not inserted");

        return _mapper.Map<EvaluetionDtoResult>(result);
    }

    public async Task<EvaluetionDtoResult> UpdateEvaluetionAsync(int id, EvaluetionDtoUpdate evaluetionDto)
    {
        var evaluationExist = await _evaluetionRepository.SelectEvaluationCouseStudante(evaluetionDto.CourseId, evaluetionDto.StudentId);
        if (evaluationExist != null && evaluationExist.Id != evaluetionDto.Id)
            throw new HttpException(HttpStatusCode.Conflict, "Evaluation already exists");

        var evaluetionResult = await _evaluetionRepository.UpdateAsync(id, _mapper.Map<Evaluetions>(evaluetionDto));
        if (evaluetionResult == null)
            throw new HttpException(HttpStatusCode.NotFound, "Evaluation not found, not updated");

        return _mapper.Map<EvaluetionDtoResult>(evaluetionResult);

    }

    public async Task<bool> DeleteEvaluetionAsync(int id)
    {
        var existEvaluetion = await _evaluetionRepository.ExistAsync(id);

        if (!existEvaluetion)
            throw new HttpException(HttpStatusCode.NotFound, "Evaluation not found");

        return await _evaluetionRepository.DeleteAsync(id);
    }

    public async Task<EvaluetionDtoResult> GetEvaluetionByIdAsync(int id)
    {
        var evaluetionResult = await _evaluetionRepository.SelectAsync(id);
        if (evaluetionResult == null)
            throw new HttpException(HttpStatusCode.NotFound, "Evaluation not found");

        return _mapper.Map<EvaluetionDtoResult>(evaluetionResult);
    }

    public async Task<IEnumerable<EvaluetionDtoResult>> GetEvaluetionsAsync()
    {
        var listEvaluetionResult = await _evaluetionRepository.SelectAllAsync();
        if (listEvaluetionResult == null)
            throw new HttpException(HttpStatusCode.NotFound, "Evaluation not found");

        return _mapper.Map<IEnumerable<EvaluetionDtoResult>>(listEvaluetionResult);
    }

    
}
