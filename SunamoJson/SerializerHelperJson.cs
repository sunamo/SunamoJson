// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
namespace SunamoJson;

/// <summary>
/// SerializerHelper vyžaduje T a musel bych ho napsat do třídy aby se mi nabídli metody
/// </summary>
public static class SerializerHelperJson
{
    /// <summary>
    /// Writes the given object instance to a Json file.
    /// <para>Object type must have a parameterless constructor.</para>
    /// <para>Only Public properties and variables will be written to the file. These can be any type though, even other classes.</para>
    /// <para>If there are public properties/variables that you do not want written to the file, decorate them with the [JsonIgnore] attribute.</para>
    /// </summary>
    /// <typeparam name="T">The type of object being written to the file.</typeparam>
    /// <param name="filePath">The file path to write the object instance to.</param>
    /// <param name="objectToWrite">The object instance to write to the file.</param>
    /// <param name="append">If false the file will be overwritten if it already exists. If true the contents will be appended to the file.</param>
    public static
#if ASYNC
    async Task<bool>
#else
    void  
#endif
 WriteToJsonFile<T>(ILogger logger,
        string path,
        T objectToWrite,
        WriteToJsonFileArgs? a = null
    )
        where T : new()
    {
        if (a == null)
        {
            a = new WriteToJsonFileArgs();
        }
        string? contentsToWriteToFile = null;
        try
        {
            contentsToWriteToFile = JsonConvert.SerializeObject(objectToWrite, a.Formatting);
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message);
            return false;
        }
        if (a.TwoBackslashToSingle)
        {
            contentsToWriteToFile = contentsToWriteToFile.Replace(@"\\", "\\");
        }
        if (a.Append)
        {
            await File.AppendAllTextAsync(path, contentsToWriteToFile);
        }
        else
        {
            await File.WriteAllTextAsync(path, contentsToWriteToFile);
        }
        return true;
    }
    /// <summary>
    /// Reads an object instance from an Json file.
    /// <para>Object type must have a parameterless constructor.</para>
    /// </summary>
    /// <typeparam name="T">The type of object to read from the file.</typeparam>
    /// <param name="filePath">The file path to read the object instance from.</param>
    /// <returns>Returns a new instance of the object read from the Json file.</returns>
    public static
#if ASYNC
    async Task<T?>
#else
    T  
#endif
 ReadFromJsonFile<T>(ILogger logger, string path, ReadFromJsonFileArgs a)
        where T : new()
    {
        var fileContents =
#if ASYNC
    await
#endif
File.ReadAllTextAsync(path);
        if (a.TwoSingleToBackslash)
        {
            fileContents = fileContents.Replace("\\", "\\\\");
        }
        T? deser = default;
        try
        {
            deser = JsonConvert.DeserializeObject<T>(fileContents);
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message);
        }
        return deser;
    }
}