namespace dynamic_json.Models;

public record TodoItem
{
    public string? Title { get; init; }
    public bool IsComplete { get; init; }
}