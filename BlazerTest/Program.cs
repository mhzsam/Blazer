using BlazerTest.Components;
using Telegram.Bot.Exceptions;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;
using Application.IService;
using Application.Service;
using Infrastructure.SetUp;
using Application.SetUp;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
// Add services to the container.
builder.Services.AddRazorComponents()
	.AddInteractiveServerComponents();

var botClient = new TelegramBotClient(builder.Configuration["TELEGRAM_CONNECTION"]);
builder.Services.AddSingleton(botClient);
string connectionString = builder.Configuration["SQL_CONNECTION"];
builder.Services.AddApplicationDBContext(connectionString);
builder.Services.AddScoped<IEnvironmentService, EnvironmentService>();
builder.Services.AddInfrastructureService();
builder.Services.AddAllApplicationServices();
builder.Services.AddSingleton<AlertService>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error", createScopeForErrors: true);
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
	.AddInteractiveServerRenderMode();

//var cts = new CancellationTokenSource();
//botClient.TestApiAsync().Wait();
//if (botClient.TestApiAsync().Result)
//	Console.WriteLine("telegram connected");
//else
//	Console.WriteLine("telegram problem ");
//botClient.StartReceiving(
//	updateHandler: HandleUpdateAsync,
//	pollingErrorHandler: HandlePollingErrorAsync,
//	receiverOptions: new ReceiverOptions { AllowedUpdates = Array.Empty<UpdateType>() },
//	cancellationToken: cts.Token
//);

app.Run();

async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
{
	if (update.Message is not { } message) return;
	if (message.Text is not { } messageText) return;

	var chatId = message.Chat.Id;

	Console.WriteLine($"Received a '{messageText}' message in chat {chatId}.");



	//ارسال پیام به کاربر
	await botClient.SendTextMessageAsync(
		chatId: chatId,
		text: "Hello! This is a test message from your bot.",
		cancellationToken: cancellationToken);
}

// متد برای مدیریت خطاها
Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
{
	var errorMessage = exception switch
	{
		ApiRequestException apiRequestException => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
		_ => exception.ToString()
	};

	Console.WriteLine(errorMessage);
	Console.WriteLine("errorrrrrrrr connect to telegram");
	return Task.CompletedTask;
}