using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureLayer.Database
{
    public interface ITodoContext
    {
        DbSet<Todo> Todo { get; set; }

        Task SaveChangesAsync();

        bool DatabaseEnsureCreated();
    }
}
