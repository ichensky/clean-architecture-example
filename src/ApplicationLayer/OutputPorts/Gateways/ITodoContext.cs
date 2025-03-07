using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace ApplicationLayer.OutputPorts.Gateways;

public interface ITodoContext
{
    DbSet<Todo> Todo { get; set; }

    Task SaveChangesAsync();

    bool DatabaseEnsureCreated();
}
