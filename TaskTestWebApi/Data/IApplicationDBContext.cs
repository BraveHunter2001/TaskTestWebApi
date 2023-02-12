using Microsoft.EntityFrameworkCore;
using TaskTestWebApi.Models;

public interface IApplicationDBContext  
{
    DbSet<Value> Values { get; set; }
    DbSet<Result> Results { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}