namespace RiskPlatform.Functions.Bots.Interfaces;
public interface IBlobStorage
{
    Task<string> GetBlobContentAsync(string containerName, string blobName, CancellationToken cancellationToken);
}
