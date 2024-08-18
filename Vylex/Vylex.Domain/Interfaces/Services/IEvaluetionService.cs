using Vylex.Domain.DTOs;

namespace Vylex.Domain.Interfaces.Services;

public interface IEvaluetionService
{
    Task<IEnumerable<EvaluetionDtoResult>> GetEvaluetionsAsync();
    Task<EvaluetionDtoResult> GetEvaluetionByIdAsync(int id);
    Task<EvaluetionDtoResult> AddEvaluetionAsync(EvaluetionDtoCreate evaluetion);
    Task<EvaluetionDtoResult> UpdateEvaluetionAsync(int id, EvaluetionDtoUpdate evaluetion);
    Task<bool> DeleteEvaluetionAsync(int id);
}
