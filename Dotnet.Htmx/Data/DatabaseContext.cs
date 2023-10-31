using Dotnet.Htmx.Models;
using Microsoft.EntityFrameworkCore;

namespace Dotnet.Htmx.Data;

public class DatabaseContext : DbContext
{
    public DbSet<TaskModel> Tasks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<TaskModel>().HasKey(x => x.Id);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("htmx-db");
    }
}