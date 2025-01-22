using Microsoft.EntityFrameworkCore;
using PokeGoTools.Data;
using PokeGoTools.Repository.IRepository;

namespace PokeGoTools.Repository
{
    public class DailyTaskRepository : IDailyTaskRepository
    {
        private readonly ApplicationDbContext _db;

        public DailyTaskRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public Task<bool> CompleteTaskAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<DailyTask> CreateAsync(DailyTask obj)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<DailyTask>> GetAllAsync(string? userId = null)
        {
            return await _db.DailyTask.Where(u=>u.UserId == userId).ToListAsync();
        }

        public Task<DailyTask> UpdateAsync(DailyTask obj)
        {
            throw new NotImplementedException();
        }
    }
}
