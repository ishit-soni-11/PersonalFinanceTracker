using System.ComponentModel.DataAnnotations;
using PersonalFinanceTracker.Models.Enums;

namespace PersonalFinanceTracker.Models.Entities
{
    public class Transaction
    {
        public int Id { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public TransactionType Type { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        public int UserId { get; set; }
        public User User { get; set; } = null!;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}