using Newtonsoft.Json;

namespace TerminalChad.Json.Extensions;

public static class JsonExtensions
{
    public static string toJson(this object o, Formatting formatting = Formatting.None)
    {
        return JsonConvert.SerializeObject(o, formatting);
    }
}
