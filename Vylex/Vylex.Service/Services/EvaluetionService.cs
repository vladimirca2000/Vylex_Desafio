using AutoMapper;
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
    public Task AddEvaluetionAsync(EvaluetionDtoCreate evaluetion)
    {
        return _repository.InsertAsync(_mapper.Map<Evaluetions>(evaluetion));
    }

    public Task DeleteEvaluetionAsync(int id)
    {
        return _repository.DeleteAsync(id);
    }

    public Task<EvaluetionDtoResult> GetEvaluetionByIdAsync(int id)
    {
        return _repository.SelectAsync(id).ContinueWith(task => _mapper.Map<EvaluetionDtoResult>(task.Result));
    }

    public Task<IEnumerable<EvaluetionDtoResult>> GetEvaluetionsAsync()
    {
        return _repository.SelectAllAsync().ContinueWith(task => _mapper.Map<IEnumerable<EvaluetionDtoResult>>(task.Result));
    }

    public Task UpdateEvaluetionAsync(int id, EvaluetionDtoUpdate evaluetion)
    {
        return _repository.UpdateAsync(id, _mapper.Map<Evaluetions>(evaluetion));
    }
}
