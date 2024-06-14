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
        throw new NotImplementedException();
    }

    public Task DeleteEvaluetionAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<EvaluetionDtoResult> GetEvaluetionByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<EvaluetionDtoResult>> GetEvaluetionsAsync()
    {
        throw new NotImplementedException();
    }

    public Task UpdateEvaluetionAsync(int id, EvaluetionDtoUpdate evaluetion)
    {
        throw new NotImplementedException();
    }
}
