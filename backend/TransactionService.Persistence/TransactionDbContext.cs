using Microsoft.EntityFrameworkCore;
using TransactionService.Domain.Entities;

namespace TransactionService.Persistence
{
    public class TransactionDbContext : DbContext
    {
        public DbSet<Transaction> Transactions => Set<Transaction>();
        public TransactionDbContext(DbContextOptions<TransactionDbContext> options) : base(options)
        {
        }
      
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {          
            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.ToTable("Transactions");

                entity.HasKey(t => t.Id);

                entity.Property(p => p.Id)
                      .ValueGeneratedOnAdd();

                entity.Property(t => t.Date)
               .IsRequired();


                entity.Property(t => t.TransactionType)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(t => t.ProductId)
                .IsRequired();

                entity.Property(t => t.Quantity)
                    .IsRequired();

                entity.Property(t => t.UnitPrice)
                    .HasColumnType("decimal(18,2)")
                    .IsRequired();

                entity.Ignore(t => t.TotalPrice);

                entity.Property(t => t.Detail)
                    .HasMaxLength(255);

                entity.Property(p => p.IsDeleted)
                      .HasDefaultValue(false);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
