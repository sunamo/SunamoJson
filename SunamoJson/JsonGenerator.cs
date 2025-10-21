// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy

namespace SunamoJson;

public class JsonGenerator
{
    private readonly StringBuilder stringBuilder = new();

    public void Pair(string key, string value)
    {
        stringBuilder.AppendLine("\"" + key + "\": " + "\"" + value + "\",");
    }

    public override string ToString()
    {
        return stringBuilder.ToString();
    }
}