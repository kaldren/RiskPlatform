namespace RiskPlatform.Modules.Bots.Infrastructure.Configuration;
public class BotsModuleOptions
{
    public ConnectionStringsOptions ConnectionStrings { get; set; } = new();
    public StorageOptions Storage { get; set; } = new();

    public class ConnectionStringsOptions
    {
        public string Default { get; set; } = string.Empty;
    }

    public class StorageOptions
    {
        public string Container { get; set; } = "botscripts";
        public string BasePath { get; set; } = "scripts/";
    }
}
