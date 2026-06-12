using LibraryService.WebAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace LibraryService.WebAPI.Services
{
    public class FraudService : IFraudService
    {
        private readonly LibraryContext _context;

        public FraudService(LibraryContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyCollection<Fraud>> GetAllAsync()
        {
            return await _context.Frauds
                .OrderByDescending(x => x.CreatedAt)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Fraud> CreateAsync(Fraud fraud)
        {
            fraud.CreatedAt = DateTime.UtcNow;
            _context.Frauds.Add(fraud);
            await _context.SaveChangesAsync();
            return fraud;
        }
    }
}
