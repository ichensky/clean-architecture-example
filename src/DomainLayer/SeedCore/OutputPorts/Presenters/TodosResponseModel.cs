using DomainLayer.Models;

namespace DomainLayer.SeedCore.OutputPorts.Presenters;

public record TodosResponseModel(IReadOnlyList<Todo> Todos);
