using GoalTrackerApp.Models;

namespace GoalTrackerApp.Services
{
    public interface IGoalService
    {
        List<Goal> GetAll();
        Goal Get(Guid id);
        void Add(Goal goal);
        void Update(Goal goal);
        void Delete(Guid id);
        void Save();
    }
}
