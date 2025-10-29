using GoalTrackerApp.Models;
using System.Text.Json;

namespace GoalTrackerApp.Services
{
    public class GoalService : IGoalService
    {
        private readonly string _filePath = "data/goals.json";
        private readonly object _lock = new();
        private List<Goal> _goals;

        public GoalService() => _goals = Load();

        private List<Goal> Load()
        {
            if (!File.Exists(_filePath))
                return new List<Goal>();
            lock (_lock)
            {
                var json = File.ReadAllText(_filePath);
                return JsonSerializer.Deserialize<List<Goal>>(json) ?? new List<Goal>();
            }
        }

        public List<Goal> GetAll() => _goals;

        public Goal Get(Guid id) => _goals.FirstOrDefault(g => g.Id == id);

        public void Add(Goal goal)
        {
            if (string.IsNullOrWhiteSpace(goal.Title))
                throw new ArgumentException("Title required");
            _goals.Add(goal);
            Save();
        }

        public void Update(Goal goal)
        {
            var existing = Get(goal.Id);
            if (existing == null) throw new Exception("Goal not found");
            existing.Title = goal.Title;
            existing.Description = goal.Description;
            existing.Type = goal.Type;
            existing.TargetDate = goal.TargetDate;
            existing.ProgressPercent = goal.ProgressPercent;
            existing.Status = goal.ProgressPercent == 100 ? GoalStatus.Completed : goal.Status;
            Save();
        }

        public void Delete(Guid id)
        {
            var goal = Get(id);
            if (goal != null)
            {
                _goals.Remove(goal);
                Save();
            }
        }

        public void Save()
        {
            lock (_lock)
            {
                var json = JsonSerializer.Serialize(_goals, new JsonSerializerOptions { WriteIndented = true });
                Directory.CreateDirectory("data");
                File.WriteAllText(_filePath, json);
            }
        }
    }
}
