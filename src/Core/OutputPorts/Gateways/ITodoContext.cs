using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using InfrastructureLayer.Database;

namespace Core.OutputPorts.Gateways
{
    public interface ITodoContext
    {
        DbSet<Todo> Todo { get; set; }

        Task SaveChangesAsync();

        bool DatabaseEnsureCreated();
    }
}
