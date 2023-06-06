using Microsoft.EntityFrameworkCore;
using RPA.Alura.Domain.Model;

namespace RPA.Alura.Infrastructure.Context;
public class RPAContext : DbContext
{
    public RPAContext(DbContextOptions<RPAContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Courses>().HasKey(m => m.Id);
        builder.Entity<Routine>().HasKey(m => m.Id);
        base.OnModelCreating(builder);
    }

    public virtual DbSet<Courses>? Courses { get; set; }
    public virtual DbSet<Routine>? Routine { get; set; }
}