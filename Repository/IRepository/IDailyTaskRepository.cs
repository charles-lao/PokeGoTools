﻿

using PokeGoTools.Data;

namespace PokeGoTools.Repository.IRepository
{
    public interface IDailyTaskRepository
    {
        public Task<DailyTask> CreateAsync(DailyTask obj);
        public Task<DailyTask> UpdateAsync(DailyTask obj);
        public Task<bool> ResetTaskAsync(string userId);
        public Task<bool> ToggleTaskAsync(int id);
        public Task<bool> DeleteAsync(int id);
        public Task<IEnumerable<DailyTask>> GetAllAsync(string? userId);

        public Task<bool> AddDefaultTasksAsync(string userId);

    }
}
