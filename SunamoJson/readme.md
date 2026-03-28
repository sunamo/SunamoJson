### SunamoJson

JSON serialization and deserialization helper library built on Newtonsoft.Json, providing simplified file I/O operations for JSON data.

Part of PlatformIndependentNuGetPackages:

- [nuget.org](https://www.nuget.org/profiles/sunamo)
- [github.org](https://github.com/sunamo/PlatformIndependentNuGetPackages)

Another links:

- [Developer site](https://sunamo.cz)

Request for new features / bug report / etc: [Mail](mailto:radek.jancik@sunamo.cz) or on GitHub

## Key Classes

- **SerializerHelperJson** - Read from and write to JSON files with configurable options
- **JsonGenerator** - Simple JSON content builder using key-value pairs
- **ReadFromJsonFileArgs** - Configuration for JSON file reading (backslash handling)
- **WriteToJsonFileArgs** - Configuration for JSON file writing (formatting, append mode, backslash handling)

## Target Frameworks

**TargetFrameworks:** `net10.0;net9.0;net8.0`

## Dependencies

- **Newtonsoft.Json** (13.0.4)
- **Microsoft.Extensions.Logging.Abstractions** (10.0.2)

## License

MIT
