using Azure.Messaging.ServiceBus;
using Azure.Storage.Blobs;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace RiskPlatform.Functions.Bots
{
    public class RunBot
    {
        private readonly ILogger<RunBot> _logger;
        private readonly BlobServiceClient _blobServiceClient;

        public RunBot(ILogger<RunBot> logger, BlobServiceClient blobServiceClient)
        {
            _logger = logger;
            _blobServiceClient = blobServiceClient;
        }

        [Function(nameof(RunBot))]
        public async Task Run(
            [ServiceBusTrigger("bot-runs-queue", Connection = "ServiceBus")]
            ServiceBusReceivedMessage message,
            ServiceBusMessageActions messageActions)
        {
            _logger.LogInformation("Message ID: {id}", message.MessageId);
            _logger.LogInformation("Message Body: {body}", message.Body);
            _logger.LogInformation("Message Content-Type: {contentType}", message.ContentType);

            // 1. Get the bot ID from the message body
            var bot = message.Body.ToObjectFromJson<RunBotMessage>();

            // 2. Get the bot script from the blob storage
            var scriptBlob = _blobServiceClient
            .GetBlobContainerClient("bots")
            .GetBlobClient($"{bot.BotId}/code/sum_script.py");

            var runDir = Path.Combine(Path.GetTempPath(), $"bot_{bot.BotId}");
            Directory.CreateDirectory(runDir);

            var scriptPath = Path.Combine(runDir, "sum_script.py");
            await scriptBlob.DownloadToAsync(scriptPath);

            // Write input.txt (input file only, output handled by script)
            var inputFilePath = Path.Combine(runDir, "input.txt");

            var inputLines = bot.InputParameters
                .Select(p => p.DefaultValue ?? "0");

            await File.WriteAllLinesAsync(inputFilePath, inputLines);

            // Run the script (script handles output)
            var startInfo = new ProcessStartInfo
            {
                FileName = @"C:\Users\drens\AppData\Local\Programs\Python\Python313\python.exe",
                Arguments = "sum_script.py",
                WorkingDirectory = runDir,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using var process = Process.Start(startInfo);

            string stdOut = await process.StandardOutput.ReadToEndAsync();
            string stdErr = await process.StandardError.ReadToEndAsync();
            process.WaitForExit();

            var outputFilePath = Path.Combine(runDir, "out.txt");

            if (File.Exists(outputFilePath))
            {
                var output = await File.ReadAllTextAsync(outputFilePath);
                _logger.LogInformation("Bot Output:\n{output}", output);
            }
            else
            {
                _logger.LogWarning("Bot did not generate out.txt. StdErr:\n{err}", stdErr);
            }

            // Complete the message
            await messageActions.CompleteMessageAsync(message);
        }
    }
}

public class RunBotMessage
{
    public int BotId { get; set; }
    public List<InputParameterDto> InputParameters { get; set; } = new();
    public List<InputFileParameterDto> InputFileParameters { get; set; } = new();
    public List<OutputFileParameterDto> OutputFileParameters { get; set; } = new();
    public Guid RunId { get; set; } = Guid.NewGuid();
}

public class InputParameterDto
{
    public string FieldName { get; set; } = default!;
    public string FieldType { get; set; } = default!; // assuming string; will parse into FieldType
    public string? FieldDescription { get; set; }
    public string? DefaultValue { get; set; }
    public bool IsRequired { get; set; }
}

public class InputFileParameterDto
{
    public string FileExtension { get; set; } = default!; // e.g. ".csv"
    public bool IsRequired { get; set; }
    public string? Description { get; set; }
}

public class OutputFileParameterDto
{
    public string FileName { get; set; } = default!; // e.g. "out.txt"
}