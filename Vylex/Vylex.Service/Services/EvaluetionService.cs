using AutoMapper;
using System.Net;
using Vylex.Domain.Common;
using Vylex.Domain.DTOs;
using Vylex.Domain.Entities;
using Vylex.Domain.Interfaces.Repositories;
using Vylex.Domain.Interfaces.Services;

namespace Vylex.Service.Services;

public class EvaluetionService : IEvaluetionService
{
    private readonly IRepository<Evaluetions> _repository;
    private readonly IMapper _mapper;
    public EvaluetionService(IRepository<Evaluetions> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<EvaluetionDtoResult> AddEvaluetionAsync(EvaluetionDtoCreate evaluetion)
    {
        var EvaluetionResult = _mapper.Map<Evaluetions>(evaluetion);
        var result = await _repository.InsertAsync(EvaluetionResult);
        if (result == null)
        {
            throw new HttpException(HttpStatusCode.BadRequest, "Evaluetion not inserted");
        }
        return _mapper.Map<EvaluetionDtoResult>(result);
    }

    public async Task<bool> DeleteEvaluetionAsync(int id)
    {
        var testeEvaluetion = await _repository.ExistAsync(id);
        if(!testeEvaluetion)
        {
            throw new HttpException(HttpStatusCode.NotFound, "Evaluetion not found");
        }
        return testeEvaluetion;
    }

    public async Task<EvaluetionDtoResult> GetEvaluetionByIdAsync(int id)
    {
        var evaluetionResult = await _repository.SelectAsync(id);
        if (evaluetionResult == null)
        {
            throw new HttpException(HttpStatusCode.NotFound, "Evaluetion not found");
        }
        return _mapper.Map<EvaluetionDtoResult>(evaluetionResult);
    }

    public async Task<IEnumerable<EvaluetionDtoResult>> GetEvaluetionsAsync()
    {
        var listEvaluetionResult = await _repository.SelectAllAsync();
        if (listEvaluetionResult == null)
        {
            throw new HttpException(HttpStatusCode.NotFound, "Evaluetion not found");
        }
        return _mapper.Map<IEnumerable<EvaluetionDtoResult>>(listEvaluetionResult);
    }

    public async Task<EvaluetionDtoResult> UpdateEvaluetionAsync(int id, EvaluetionDtoUpdate evaluetion)
    {
        var evaluetionResult = await _repository.UpdateAsync(id, _mapper.Map<Evaluetions>(evaluetion));
        if (evaluetionResult == null)
        {
            throw new HttpException(HttpStatusCode.NotFound, "Evaluetion not found, not updated");
        }
        return _mapper.Map<EvaluetionDtoResult>(evaluetionResult);
    }
}
