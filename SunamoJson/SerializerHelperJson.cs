namespace SunamoJson;

/// <summary>
/// Helper class for JSON serialization and deserialization.
/// </summary>
public static class SerializerHelperJson
{
    /// <summary>
    /// Writes the given object instance to a JSON file.
    /// <para>Object type must have a parameterless constructor.</para>
    /// <para>Only public properties and variables will be written to the file. These can be any type though, even other classes.</para>
    /// <para>If there are public properties/variables that you do not want written to the file, decorate them with the [JsonIgnore] attribute.</para>
    /// </summary>
    /// <typeparam name="T">The type of object being written to the file.</typeparam>
    /// <param name="logger">The logger instance for error logging.</param>
    /// <param name="path">The file path to write the object instance to.</param>
    /// <param name="objectToWrite">The object instance to write to the file.</param>
    /// <param name="args">Optional arguments for controlling the write behavior.</param>
    /// <returns>True if the write was successful; otherwise, false.</returns>
    public static
#if ASYNC
    async Task<bool>
#else
    void
#endif
 WriteToJsonFile<T>(ILogger logger,
        string path,
        T objectToWrite,
        WriteToJsonFileArgs? args = null
    )
        where T : new()
    {
        if (args == null)
        {
            args = new WriteToJsonFileArgs();
        }
        string? contentsToWriteToFile = null;
        try
        {
            contentsToWriteToFile = JsonConvert.SerializeObject(objectToWrite, args.Formatting);
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message);
            return false;
        }
        if (args.TwoBackslashToSingle)
        {
            contentsToWriteToFile = contentsToWriteToFile.Replace(@"\\", "\\");
        }
        if (args.Append)
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
    /// Reads an object instance from a JSON file.
    /// <para>Object type must have a parameterless constructor.</para>
    /// </summary>
    /// <typeparam name="T">The type of object to read from the file.</typeparam>
    /// <param name="logger">The logger instance for error logging.</param>
    /// <param name="path">The file path to read the object instance from.</param>
    /// <param name="args">Arguments for controlling the read behavior.</param>
    /// <returns>Returns a new instance of the object read from the JSON file, or null if deserialization fails.</returns>
    public static
#if ASYNC
    async Task<T?>
#else
    T
#endif
 ReadFromJsonFile<T>(ILogger logger, string path, ReadFromJsonFileArgs args)
        where T : new()
    {
        var fileContents =
#if ASYNC
    await
#endif
File.ReadAllTextAsync(path);
        if (args.TwoSingleToBackslash)
        {
            fileContents = fileContents.Replace("\\", "\\\\");
        }
        T? deserializedObject = default;
        try
        {
            deserializedObject = JsonConvert.DeserializeObject<T>(fileContents);
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message);
        }
        return deserializedObject;
    }
}