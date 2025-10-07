using dynamic_json.Models;
using Newtonsoft.Json.Linq;

namespace dynamic_json.JsonProcessors;

public class TodoItemProcessor : IJsonProcessor
{
    public bool CanProcess(JObject json)
    {
        var canProcess = json.ContainsKey(nameof(TodoItem.Title)) && json.ContainsKey(nameof(TodoItem.IsComplete));
        return canProcess;
    }

    public object? Process(JObject json)
    {
        if (!CanProcess(json)) return null;

        var todoItem = json.ToObject<TodoItem>();

        // 

        return todoItem with { IsComplete = true };
    }
}