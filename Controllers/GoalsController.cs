using Microsoft.AspNetCore.Mvc;
using GoalTrackerApp.Models;
using GoalTrackerApp.Services;

namespace GoalTrackerApp.Controllers
{
    public class GoalsController : Controller
    {
        private readonly IGoalService _service;

        public GoalsController(IGoalService service) => _service = service;

        public IActionResult Index(string type, string status)
        {
            var goals = _service.GetAll();
            if (!string.IsNullOrEmpty(type))
                goals = goals.Where(g => g.Type.ToString() == type).ToList();
            if (!string.IsNullOrEmpty(status))
                goals = goals.Where(g => g.Status.ToString() == status).ToList();
            foreach (var goal in goals)
            {
                if (goal.TargetDate < DateTime.Today && goal.Status == GoalStatus.Active)
                    ViewData[$"alert_{goal.Id}"] = "Target date passed!";
            }
            return View(goals);
        }

        public IActionResult Details(Guid id)
        {
            var goal = _service.Get(id);
            if (goal == null) return NotFound();
            return View(goal);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Goal goal)
        {
            if (ModelState.IsValid)
            {
                _service.Add(goal);
                return RedirectToAction(nameof(Index));
            }
            return View(goal);
        }

        public IActionResult Edit(Guid id)
        {
            var goal = _service.Get(id);
            if (goal == null) return NotFound();
            return View(goal);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, Goal goal)
        {
            if (ModelState.IsValid)
            {
                _service.Update(goal);
                return RedirectToAction(nameof(Index));
            }
            return View(goal);
        }

        public IActionResult Delete(Guid id)
        {
            var goal = _service.Get(id);
            if (goal == null) return NotFound();
            return View(goal);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
