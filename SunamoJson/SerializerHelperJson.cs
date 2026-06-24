namespace SunamoJson;

public static class SerializerHelperJson
{
    public static
    async Task<bool>
 WriteToJsonFile<T>(ILogger logger,
        string path,
        T objectToWrite,
        WriteToJsonFileArgs? args = null
    )
        where T : new()
    {
        args ??= new WriteToJsonFileArgs();
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
            await FileAsync.AppendAllTextAsync(path, contentsToWriteToFile);
        }
        else
        {
            await FileAsync.WriteAllTextAsync(path, contentsToWriteToFile);
        }
        return true;
    }

    public static
    async Task<T?>
 ReadFromJsonFile<T>(ILogger logger, string path, ReadFromJsonFileArgs args)
        where T : new()
    {
        var fileContents =
    await
FileAsync.ReadAllTextAsync(path);
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
