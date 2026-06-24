namespace SunamoJson.Args;

public class WriteToJsonFileArgs
{
    public Newtonsoft.Json.Formatting Formatting { get; set; } = Newtonsoft.Json.Formatting.None;

    public bool Append { get; set; } = false;

    // Note: This will not work for deserialization from file, as it would convert \" to \".
    public bool TwoBackslashToSingle { get; set; } = false;
}
