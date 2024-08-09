namespace SunamoJson;

public class JsonGenerator
{
    private readonly StringBuilder sb = new();

    public void Pair(string key, string value)
    {
        sb.AppendLine("\"" + key + "\": " + "\"" + value + "\",");
    }

    public override string ToString()
    {
        return sb.ToString();
    }
}