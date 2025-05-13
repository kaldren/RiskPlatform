using Azure.Messaging.ServiceBus;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace RiskPlatform.Functions.Bots
{
    public class RunBot
    {
        private readonly ILogger<RunBot> _logger;

        public RunBot(ILogger<RunBot> logger)
        {
            _logger = logger;
        }

        [Function(nameof(RunBot))]
        public async Task Run(
            [ServiceBusTrigger("run-bot-queue", Connection = "ServiceBus")]
            ServiceBusReceivedMessage message,
            ServiceBusMessageActions messageActions)
        {
            _logger.LogInformation("Message ID: {id}", message.MessageId);
            _logger.LogInformation("Message Body: {body}", message.Body);
            _logger.LogInformation("Message Content-Type: {contentType}", message.ContentType);

            // Complete the message
            await messageActions.CompleteMessageAsync(message);
        }
    }
}
