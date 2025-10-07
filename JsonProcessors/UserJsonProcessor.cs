using dynamic_json.Models;
using Newtonsoft.Json.Linq;

namespace dynamic_json.JsonProcessors;

public class UserJsonProcessor : IJsonProcessor
{
    // "{\"Name\":\"John Doe\",\"Email\":\"john.doe@example.com\"}"
    public bool CanProcess(JObject json)
    {
        return json.ContainsKey(nameof(User.Name)) && json.ContainsKey(nameof(User.Email));
    }
    public object? Process(JObject json)
    {
        if (!CanProcess(json)) return null;

        var user = json.ToObject<User>();

        // update user
        return user with { Name = "John Doe 2" };
    }
}