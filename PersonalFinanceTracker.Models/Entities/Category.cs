using System.ComponentModel.DataAnnotations;
using PersonalFinanceTracker.Models.Enums;

namespace PersonalFinanceTracker.Models.Entities
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        [Required]
        public TransactionType Type { get; set; }

        public string Color { get; set; } = "#3498db";

        public int UserId { get; set; }
        public User User { get; set; } = null!;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
        public ICollection<Budget> Budgets { get; set; } = new List<Budget>();
    }
}