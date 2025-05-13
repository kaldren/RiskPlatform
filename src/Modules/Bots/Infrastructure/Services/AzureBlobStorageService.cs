using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using RiskPlatform.Modules.Bots.Application.Interfaces;

namespace RiskPlatform.Modules.Bots.Infrastructure.Services;

public class AzureBlobStorageService : IStorageService
{
    private readonly BlobServiceClient _blobServiceClient;
    private readonly string _containerName;

    public AzureBlobStorageService(BlobServiceClient blobServiceClient, IConfiguration config)
    {
        _blobServiceClient = blobServiceClient;
        _containerName = config["Modules:Bots:AzureBlobStorage:BotsContainerName"];
    }

    public async Task<string> UploadScriptAsync(int botId, IFormFile file)
    {
        // Upload to bots/{botId}/code/{file}
        var containerClient = _blobServiceClient.GetBlobContainerClient(_containerName);

        // Upload the file to bots/{botId}/code/{file} and overwrite if needed
        var blobClient = containerClient.GetBlobClient($"{botId}/script/{file.FileName}");
        await blobClient.UploadAsync(file.OpenReadStream(), true);

        return blobClient.Uri.ToString();
    }
}
