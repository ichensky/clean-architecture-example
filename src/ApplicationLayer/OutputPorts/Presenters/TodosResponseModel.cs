using DomainLayer.Models;

namespace ApplicationLayer.OutputPorts.Presenters;

public record TodosResponseModel(IReadOnlyList<Todo> Todos);
