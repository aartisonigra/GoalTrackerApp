using System;
using System.ComponentModel.DataAnnotations;

namespace GoalTrackerApp.Models
{
    public enum GoalType { ShortTerm, LongTerm }
    public enum GoalStatus { Active, Completed }

    public class Goal
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        public GoalType Type { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime TargetDate { get; set; }

        [Range(0, 100)]
        public int ProgressPercent { get; set; } = 0;

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public GoalStatus Status { get; set; } = GoalStatus.Active;
    }
}
