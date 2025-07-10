using Microsoft.EntityFrameworkCore;
using PersonalFinanceTracker.Models.Entities;

namespace PersonalFinanceTracker.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Budget> Budgets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.Id);
                entity.HasIndex(u => u.Email).IsUnique();
                entity.Property(u => u.Email).HasMaxLength(100);
                entity.Property(u => u.FirstName).HasMaxLength(50);
                entity.Property(u => u.LastName).HasMaxLength(50);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Name).HasMaxLength(100);
                entity.Property(c => c.Color).HasMaxLength(7);
                entity.HasOne(c => c.User)
                      .WithMany(u => u.Categories)
                      .HasForeignKey(c => c.UserId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.HasKey(t => t.Id);
                entity.Property(t => t.Amount).HasColumnType("decimal(18,2)");
                entity.Property(t => t.Description).HasMaxLength(500);
                entity.HasOne(t => t.Category)
                      .WithMany(c => c.Transactions)
                      .HasForeignKey(t => t.CategoryId)
                      .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(t => t.User)
                      .WithMany(u => u.Transactions)
                      .HasForeignKey(t => t.UserId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Budget>(entity =>
            {
                entity.HasKey(b => b.Id);
                entity.Property(b => b.Amount).HasColumnType("decimal(18,2)");
                entity.HasOne(b => b.Category)
                      .WithMany(c => c.Budgets)
                      .HasForeignKey(b => b.CategoryId)
                      .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(b => b.User)
                      .WithMany(u => u.Budgets)
                      .HasForeignKey(b => b.UserId)
                      .OnDelete(DeleteBehavior.Cascade);
                entity.HasIndex(b => new { b.UserId, b.CategoryId, b.Month, b.Year })
                      .IsUnique();
            });
        }
    }
}