namespace SunamoJson.Args;

/// <summary>
/// Arguments for writing JSON to a file.
/// </summary>
public class WriteToJsonFileArgs
{
    /// <summary>
    /// Gets or sets the JSON formatting style.
    /// </summary>
    public Newtonsoft.Json.Formatting Formatting { get; set; } = Newtonsoft.Json.Formatting.None;

    /// <summary>
    /// Gets or sets a value indicating whether to append to the file instead of overwriting.
    /// </summary>
    public bool Append { get; set; } = false;

    /// <summary>
    /// Gets or sets a value indicating whether to replace double backslashes with single backslashes.
    /// Note: This will not work for deserialization from file, as it would convert \" to \".
    /// </summary>
    public bool TwoBackslashToSingle { get; set; } = false;
}