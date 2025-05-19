using Azure.Storage.Blobs;
using RiskPlatform.Functions.Bots.Interfaces;

namespace RiskPlatform.Functions.Bots.Services;

public class AzureStorageService : IBlobStorage
{
    private readonly BlobServiceClient _blobServiceClient;

    public AzureStorageService(BlobServiceClient blobServiceClient)
    {
        _blobServiceClient = blobServiceClient;
    }

    public Task<string> GetBlobContentAsync(string containerName, string blobName, CancellationToken cancellationToken)
    {
        var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);

        var blobClient = containerClient.GetBlobClient(blobName);

        return blobClient.DownloadContentAsync(cancellationToken)
            .ContinueWith(task =>
            {
                var response = task.Result;
                return response.Value.Content.ToString();
            }, cancellationToken);
    }
}
