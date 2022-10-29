using Filterbot.Web.Configurations;
using Filterbot.Web.HostedServices;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddMvc()
                .AddNewtonsoftJson();

#region Telegram Client Configuration

var telegramConfiguration = builder.Configuration.GetSection("TelegramConfiguration").Get<TelegramBotConfiguration>();
var telegramClient = new TelegramBotClient(telegramConfiguration.Token);

builder.Services.AddSingleton(telegramConfiguration);
builder.Services.AddSingleton<ITelegramBotClient>(telegramClient);

#endregion

#region Hosted Services

builder.Services.AddHostedService<WebhookHostedService>();

#endregion


var app = builder.Build();

app.MapControllers();
app.UseStaticFiles();
app.MapRazorPages();
app.Run();