using System.ComponentModel.DataAnnotations;

namespace PersonalFinanceTracker.Models.Entities
{
    public class Budget
    {
        public int Id { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public int Month { get; set; }

        [Required]
        public int Year { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        public int UserId { get; set; }
        public User User { get; set; } = null!;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}