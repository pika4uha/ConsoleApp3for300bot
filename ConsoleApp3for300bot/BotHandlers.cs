using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types;

namespace ConsoleApp3for300bot;

public class BotHandlers
{
    private static DBfoods _dbFoods = new DBfoods();

    public static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update,
        CancellationToken cancellationToken)
    {
        if (update.Message is not { } message)
        {
            return;
        }

        if (message.Text is not { } messageText)
        {
            return;
        }

        string response = "Неизвестная команда (для получения новой шутки введите /help)";
        
        int foodCounter = 1;
        
        if (messageText == "/get_food")
        {
            
            if(foodCounter == 1)
            {
                try
                {
                    response = _dbFoods.GetRandomFood();
                    foodCounter++;
                }
                catch (Exception e)
                {
                    response = "Ошибка запроса к базе данных. Пожалуйста повторите запрос позже";
                }
            }
            if(foodCounter == 2)
            {
                try
                {
                    response = _dbFoods.GetRandomDrink();
                    foodCounter++;
                }
                catch (Exception e)
                {
                    response = "Ошибка запроса к базе данных. Пожалуйста повторите запрос позже";
                }
            }
            if(foodCounter == 3)
            {
                try
                {
                    response = _dbFoods.GetRandomDessert();
                    foodCounter=1;
                }
                catch (Exception e)
                {
                    response = "Ошибка запроса к базе данных. Пожалуйста повторите запрос позже";
                }
            }
        }

        Message sentMessage = await botClient.SendTextMessageAsync
        (
            chatId: message.Chat.Id,
            text: response,
            cancellationToken: cancellationToken
        );
    }


    public static Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception,
        CancellationToken cancellationToken)
    {
        var ErrorMessage = exception switch
        {
            ApiRequestException apiRequestException
                => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
            _ => exception.ToString()
        };

        Console.WriteLine(ErrorMessage);
        return Task.CompletedTask;
    }
}