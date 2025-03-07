using ApplicationLayer.OutputPorts.Gateways;
using DomainLayer.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureLayer.Database;

public class TodoContext : DbContext, ITodoContext
{
    public DbSet<Todo> Todo { get; set; }

    public bool DatabaseEnsureCreated()
    {
        return this.Database.EnsureCreated();
    }

    public Task SaveChangesAsync()
    {
        return base.SaveChangesAsync();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var keepAliveConnection = new SqliteConnection("DataSource=myshareddb;mode=memory;cache=shared");
        keepAliveConnection.Open();

        optionsBuilder.UseSqlite(keepAliveConnection);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Todo>().HasKey(x => x.Id);
        modelBuilder.Entity<Todo>().Property(x => x.Title).HasMaxLength(100);
        modelBuilder.Entity<Todo>().Property(x => x.UpdateDate).IsConcurrencyToken();
    }
}
