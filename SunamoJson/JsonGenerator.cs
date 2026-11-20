namespace SunamoJson;

/// <summary>
/// Represents the json generator type.
/// </summary>
public class JsonGenerator
{
    private readonly StringBuilder stringBuilder = new();

    /// <summary>
    /// Pair.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <param name="value">The value.</param>
    public void Pair(string key, string value)
    {
        stringBuilder.AppendLine($"\"{key}\": \"{value}\",");
    }

    /// <summary>
    /// To string.
    /// </summary>
    /// <returns>The to string result.</returns>
    public override string ToString()
    {
        return stringBuilder.ToString();
    }
}
