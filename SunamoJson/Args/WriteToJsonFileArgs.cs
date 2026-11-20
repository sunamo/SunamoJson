namespace SunamoJson.Args;

/// <summary>
/// Represents the write to json file args type.
/// </summary>
public class WriteToJsonFileArgs
{
    /// <summary>
    /// Gets or sets the formatting.
    /// </summary>
    public Newtonsoft.Json.Formatting Formatting { get; set; } = Newtonsoft.Json.Formatting.None;

    /// <summary>
    /// Gets or sets the append.
    /// </summary>
    public bool Append { get; set; } = false;

    // Note: This will not work for deserialization from file, as it would convert \" to \".
    /// <summary>
    /// Gets or sets the two backslash to single.
    /// </summary>
    public bool TwoBackslashToSingle { get; set; } = false;
}
