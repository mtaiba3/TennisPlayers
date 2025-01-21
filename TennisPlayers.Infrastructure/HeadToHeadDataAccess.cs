using System.Reflection;

namespace TennisPlayers.Infrastructure;

public class HeadToHeadDataAccess
{
    public string GetEmbeddedJson()
    {
        var assembly = Assembly.GetExecutingAssembly();

        var resourceName = "TennisPlayers.Infrastructure.headtohead.json";

        using (var stream = assembly.GetManifestResourceStream(resourceName))
        {
            if (stream == null)
                throw new Exception($"Resource {resourceName} not found.");

            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }
}