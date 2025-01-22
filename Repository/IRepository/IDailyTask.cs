

using PokeGoTools.Data;

namespace PokeGoTools.Repository.IRepository
{
    public interface IDailyTask
    {
        public Task<DailyTask> CreateAsync(DailyTask obj);


    }
}
