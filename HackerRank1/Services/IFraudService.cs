using LibraryService.WebAPI.Data;

namespace LibraryService.WebAPI.Services
{
    public interface IFraudService
    {
        Task<IReadOnlyCollection<Fraud>> GetAllAsync();
        Task<Fraud> CreateAsync(Fraud fraud);
    }
}
