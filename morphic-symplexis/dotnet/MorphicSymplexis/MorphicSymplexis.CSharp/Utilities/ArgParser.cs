namespace MorphicSymplexis.CSharp
{
    // A minimal ArgParser to be used for stand-alone scripts
    public static class ArgParser
    {
        public static Dictionary<string, string> Parse(IEnumerable<string> args)
        {
            var result = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            foreach (var arg in args)
            {
                if (arg.StartsWith("--"))
                {
                    var parts = arg[2..].Split('=', 2);
                    if (parts.Length == 2)
                        result[parts[0]] = parts[1];
                    else
                        result[parts[0]] = "true"; // e.g. --verbose
                }
            }

            return result;
        }

        public static T? Get<T>(Dictionary<string, string> args, string key, T? defaultValue = default)
        {
            if (args.TryGetValue(key, out var val))
            {
                try
                {
                    return (T)Convert.ChangeType(val, typeof(T));
                }
                catch
                {
                    Console.WriteLine($"Warning: Could not convert '{val}' to type {typeof(T).Name}");
                }
            }
            return defaultValue;
        }
    }
}
