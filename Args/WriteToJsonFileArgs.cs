namespace SunamoJson.Args;


public class WriteToJsonFileArgs
{
    public Newtonsoft.Json.Formatting Formatting { get; set; } = Newtonsoft.Json.Formatting.None;
    public bool Append { get; set; } = false;
    public bool TwoBackslashToSingle { get; set; } = false;
}