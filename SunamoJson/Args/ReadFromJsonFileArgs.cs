namespace SunamoJson.Args;

/// <summary>
/// Arguments for reading JSON from a file.
/// </summary>
public class ReadFromJsonFileArgs
{
    /// <summary>
    /// Gets or sets a value indicating whether to replace single backslashes with double backslashes.
    /// </summary>
    public bool TwoSingleToBackslash { get; set; } = false;
}