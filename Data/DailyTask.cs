using System.ComponentModel.DataAnnotations.Schema;

namespace PokeGoTools.Data
{
    public class DailyTask
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsCompleted { get; set; }
        public DateOnly LastUpdated { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
    }
}
