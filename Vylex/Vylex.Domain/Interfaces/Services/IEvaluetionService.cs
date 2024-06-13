using Vylex.Domain.DTOs;

namespace Vylex.Domain.Interfaces.Services;

public interface IEvaluetionService
{
    Task<IEnumerable<EvaluetionDtoResult>> GetEvaluetionsAsync();
    Task<EvaluetionDtoResult> GetEvaluetionByIdAsync(int id);
    Task AddEvaluetionAsync(EvaluetionDtoCreate evaluetion);
    Task UpdateEvaluetionAsync(int id, EvaluetionDtoUpdate evaluetion);
    Task DeleteEvaluetionAsync(int id);
}
