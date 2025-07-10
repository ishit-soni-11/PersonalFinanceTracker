using System.ComponentModel.DataAnnotations;

namespace PersonalFinanceTracker.Models.Entities
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string PasswordHash { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<Category> Categories { get; set; } = new List<Category>();
        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
        public ICollection<Budget> Budgets { get; set; } = new List<Budget>();
    }
}