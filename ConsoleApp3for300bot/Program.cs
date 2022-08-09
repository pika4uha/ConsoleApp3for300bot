using ConsoleApp3for300bot;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

var botClient = new TelegramBotClient("5479783082:AAETlBngvFso7gebCYRwgWB6RVY3VKWDtbo");

using var cts = new CancellationTokenSource();

var receiverOptions = new ReceiverOptions
{
    AllowedUpdates = Array.Empty<UpdateType>()
};

botClient.StartReceiving(
    updateHandler: BotHandlers.HandleUpdateAsync,
    pollingErrorHandler: BotHandlers.HandlePollingErrorAsync,
    receiverOptions: receiverOptions,
    cancellationToken: cts.Token
);

var me = await botClient.GetMeAsync();

Console.WriteLine("Bot started");
Console.WriteLine($"Start listening for @{me.Username}");
Console.WriteLine("Press enter for stop");
Console.ReadKey();

cts.Cancel();

Console.WriteLine("Bot stopped");