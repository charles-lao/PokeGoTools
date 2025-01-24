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

        public async Task<bool> AddDefaultTasksAsync(string userId)
        {
            var defaultTasks = new List<DailyTask>
            {
                new DailyTask {Name="Complete Daily Pokémon Catch", IsCompleted=false, LastUpdated=DateOnly.FromDateTime(DateTime.Today.AddDays(-1)), UserId = userId},
                new DailyTask {Name="Complete Daily Pokéstop Spin", IsCompleted=false, LastUpdated=DateOnly.FromDateTime(DateTime.Today.AddDays(-1)), UserId = userId},
                new DailyTask {Name="Send Gifts to Friends", IsCompleted=false, LastUpdated=DateOnly.FromDateTime(DateTime.Today.AddDays(-1)), UserId = userId},
                new DailyTask {Name="Open Gifts from Friends", IsCompleted=false, LastUpdated=DateOnly.FromDateTime(DateTime.Today.AddDays(-1)), UserId = userId},
                new DailyTask {Name="Complete Daily Field Research Stamp", IsCompleted=false, LastUpdated=DateOnly.FromDateTime(DateTime.Today.AddDays(-1)), UserId = userId},
                new DailyTask {Name="Earn 50 PokéCoins from Gyms", IsCompleted=false, LastUpdated=DateOnly.FromDateTime(DateTime.Today.AddDays(-1)), UserId = userId},
            };

            _db.DailyTask.AddRange(defaultTasks);
            _db.SaveChanges();
            return true;
        }
    }
}
