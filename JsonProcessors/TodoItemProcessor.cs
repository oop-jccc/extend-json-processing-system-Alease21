using dynamic_json.Models;
using Newtonsoft.Json.Linq;

namespace dynamic_json.JsonProcessors;

public class TodoItemProcessor : IJsonProcessor
{
    public bool CanProcess(JObject json)
    {
        return json.ContainsKey(nameof(TodoItem.Title)) && json.ContainsKey(nameof(TodoItem.IsComplete));
    }

    public object? Process(JObject json)
    {
        if (!CanProcess(json)) return null;

        var todoItem = json.ToObject<TodoItem>();

        // update user
        return todoItem with { IsComplete = true };
    }
}