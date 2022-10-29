using Filterbot.Web.Configurations;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;

namespace Filterbot.Web.HostedServices;

public class WebhookHostedService : IHostedService
{
    private readonly ILogger<WebhookHostedService> _logger;
    private readonly TelegramBotConfiguration _botConfig;
    private readonly ITelegramBotClient _botClient;

    public WebhookHostedService(ILogger<WebhookHostedService> logger,
        ITelegramBotClient botClient,
        TelegramBotConfiguration botConfig)
    {
        _logger = logger;
        _botClient = botClient;
        _botConfig = botConfig;
    }
    
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Setting webhook: {WebhookAddress}", _botConfig.HostAddress);
        
        await _botClient.SetWebhookAsync(
            url: _botConfig.HostAddress,
            cancellationToken: cancellationToken);
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Removing webhook");
        await _botClient.DeleteWebhookAsync(cancellationToken: cancellationToken);
    }
}