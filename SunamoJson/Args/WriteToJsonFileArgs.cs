namespace SunamoJson.Args;


public class WriteToJsonFileArgs
{
    public Newtonsoft.Json.Formatting Formatting { get; set; } = Newtonsoft.Json.Formatting.None;
    public bool Append { get; set; } = false;
    /// <summary>
    /// Nebude fungovat pro deserializaci ze souboru
    /// Při deserializaci by se mi udělalo \\" z \" - musel bych mít seznam všeho co navrátit
    /// </summary>
    public bool TwoBackslashToSingle { get; set; } = false;
}