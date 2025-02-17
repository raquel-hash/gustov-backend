using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Data
{
    public class GustovDbContext: DbContext
    {
        public GustovDbContext(DbContextOptions<GustovDbContext> options) : base(options) { }

        public DbSet<User> User { get; set; }
        public DbSet<Dish> Dish { get; set; }
        public DbSet<Sale> Sale { get; set; }
        public DbSet<SaleItem> SaleItem { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dish>()
                .ToTable("Dish")
                .Property(d => d.Price)
                .HasColumnType("decimal(18,2)");

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Sale>()
                .HasMany(s => s.SaleItems)
                .WithOne(si => si.Sale)
                .HasForeignKey(si => si.SaleId);

            modelBuilder.Entity<SaleItem>()
                .HasOne(si => si.Dish)
                .WithMany()
                .HasForeignKey(si => si.DishId);

            modelBuilder.Entity<Sale>()
                .Property(s => s.TotalAmount)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<SaleItem>()
                .Property(si => si.Price)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<SaleItem>()
                .Property(si => si.Subtotal)
                .HasColumnType("decimal(18,2)");
        }
    }
}
