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