using Microsoft.EntityFrameworkCore;
using Models;

namespace TaskTestWebApi.Data
{
    public class ApplicationDbContext : DbContext, IApplicationDBContext
    {
        public DbSet<Value> Values { get; set; }
        public DbSet<Result> Results { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option) { }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);
        }
    }
}
