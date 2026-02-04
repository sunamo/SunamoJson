namespace SunamoJson;

/// <summary>
/// Helper class for generating JSON content.
/// </summary>
public class JsonGenerator
{
    private readonly StringBuilder stringBuilder = new();

    /// <summary>
    /// Adds a key-value pair to the JSON content.
    /// </summary>
    /// <param name="key">The JSON property key.</param>
    /// <param name="value">The JSON property value.</param>
    public void Pair(string key, string value)
    {
        stringBuilder.AppendLine("\"" + key + "\": " + "\"" + value + "\",");
    }

    /// <summary>
    /// Returns the generated JSON content as a string.
    /// </summary>
    /// <returns>The generated JSON string.</returns>
    public override string ToString()
    {
        return stringBuilder.ToString();
    }
}