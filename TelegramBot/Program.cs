using MyLib;
using Newtonsoft.Json;
using System;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramBot
{
    class Program
    {



        
        static void Main(string[] args)
        {

            

            String token = "API token from create bot";
            var client = new TelegramBotClient(token);
            client.StartReceiving(Update, Error);
            Console.ReadLine();


            async static Task Update(ITelegramBotClient client, Update update, CancellationToken cancellationToken)
            {
                string URI = "https://bank.gov.ua/NBUStatService/v1/statdirectory/exchange?json";
                string jsonFromServer = Web.GetWebContent(URI);
                List<CurrencyRate> currRates = JsonConvert.DeserializeObject<List<CurrencyRate>>(jsonFromServer);

                var dollars = currRates.Find(p => p.cc == "USD");
                var euro = currRates.Find(p => p.cc == "EUR");


                var message = update.Message;
                if (message.Text != null)
                {
                    if (message.Text.ToLower().Contains("dolar"))
                    {
                        await client.SendTextMessageAsync(message.Chat.Id, $"1 {dollars.txt} = {dollars.rate} Грн.");
                    }

                    if (message.Text.ToLower().Contains("euro"))
                    {
                        await client.SendTextMessageAsync(message.Chat.Id, "Тут взагалі треш, тримайся друже)");
                        await client.SendTextMessageAsync(message.Chat.Id, $"1 {euro.txt} = {euro.rate} Грн.");
                        await client.SendTextMessageAsync(message.Chat.Id, "Давай краще всі покажу?");
                    }
                    if (message.Text.ToLower().Contains("yes"))
                    {
                        foreach (var item in currRates)
                        {
                            await client.SendTextMessageAsync(message.Chat.Id, $"1 {item.txt} = {item.rate} Грн.");
                        }
                        
                        
                    }

                    if (message.Text.ToLower().Contains("25"))
                    {
                        List<CurrencyRate> currRate10 = currRates.FindAll(p => p.rate >25.0);
                        foreach (var item in currRate10)
                        {
                            await client.SendTextMessageAsync(message.Chat.Id, $"1 {item.txt} = {item.rate} Грн.");
                        }


                    }

                }

            }

            static Task Error(ITelegramBotClient arg1, Exception arg2, CancellationToken arg3)
            {
                throw new NotImplementedException();
            }


            


        }

    }
      
}

   

