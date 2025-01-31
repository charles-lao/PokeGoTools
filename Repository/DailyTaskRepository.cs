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
        public async Task<bool> ToggleTaskAsync(int id)
        {
            var objFromDb = await _db.DailyTask.FirstOrDefaultAsync(u => u.Id == id);
            if(objFromDb != null)
            {
                objFromDb.IsCompleted = !objFromDb.IsCompleted;
                objFromDb.LastUpdated = DateOnly.FromDateTime(DateTime.Now);
                _db.DailyTask.Update(objFromDb);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<DailyTask> CreateAsync(DailyTask newTask)
        {
            await _db.DailyTask.AddAsync(newTask);
            await _db.SaveChangesAsync();

            return newTask;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var task = await _db.DailyTask.FirstOrDefaultAsync(u => u.Id == id);
            if (task != null)
            {
                _db.DailyTask.Remove(task);
                return (await _db.SaveChangesAsync()) > 0;
            }
            return false;
        }

        public async Task<IEnumerable<DailyTask>> GetAllAsync(string? userId = null)
        {
            return await _db.DailyTask.Where(u=>u.UserId == userId).ToListAsync();
        }

        public Task<DailyTask> UpdateAsync(DailyTask obj)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ResetTaskAsync(string userId)
        {
            var userTasks = await _db.DailyTask.Where(u => u.UserId == userId).ToListAsync();

            foreach(var task in userTasks)
            {
                if (task.LastUpdated != DateOnly.FromDateTime(DateTime.Now))
                {
                    task.IsCompleted = false;
                }
            }
            return true;
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
