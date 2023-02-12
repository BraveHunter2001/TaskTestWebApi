using Microsoft.EntityFrameworkCore;
using TaskTestWebApi.Models;

namespace TaskTestWebApi.Data
{
    public class ApplicationDbContext : DbContext, IApplicationDBContext
    {
        public DbSet<Value> Values { get; set; }
        public DbSet<Result> Results { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Result>()
                .Property(p => p.MinimalDate)
                .HasConversion
                (
                    src => src.Kind == DateTimeKind.Utc ? src : DateTime.SpecifyKind(src, DateTimeKind.Utc),
                    dst => dst.Kind == DateTimeKind.Utc ? dst : DateTime.SpecifyKind(dst, DateTimeKind.Utc)
                );
            builder.Entity<Value>()
               .Property(p => p.Date)
               .HasConversion
               (
                   src => src.Kind == DateTimeKind.Utc ? src : DateTime.SpecifyKind(src, DateTimeKind.Utc),
                   dst => dst.Kind == DateTimeKind.Utc ? dst : DateTime.SpecifyKind(dst, DateTimeKind.Utc)
               );

            base.OnModelCreating(builder);
        }
    }
}
