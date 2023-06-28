using Microsoft.VisualBasic;
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

            String token = "Token";
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
                    if (message.Text.ToLower().Contains("start"))
                    {
                        await client.SendTextMessageAsync(message.Chat.Id, "Привіт, я бот що поазує курс валют по Національному банку");
                        await client.SendTextMessageAsync(message.Chat.Id, "Натисни 1 якщо хочеш побачити курс долара");
                        await client.SendTextMessageAsync(message.Chat.Id, "2 курс євро");
                        await client.SendTextMessageAsync(message.Chat.Id, "Або 3 якщо потрібно побачити весь список");
                        await client.SendTextMessageAsync(message.Chat.Id, "Також можу показати всі валюти що дорожчі за 25 гривень, для цього натисни 4");
                    }



                    if (message.Text.ToLower().Contains("1"))
                    {
                        await client.SendTextMessageAsync(message.Chat.Id, $"1 {dollars.txt} = {dollars.rate} Грн.");
                    }

                    if (message.Text.ToLower().Contains("2"))
                    {
                        await client.SendTextMessageAsync(message.Chat.Id, "Тут взагалі треш, тримайся друже, може карще анекдот розкажу? напиши мені так чи ні)");

                    }

                    if (message.Text.ToLower().Contains("ні"))
                    {

                        await client.SendTextMessageAsync(message.Chat.Id, $"1 {euro.txt} = {euro.rate} Грн.");

                    }

                    if (message.Text.ToLower().Contains("так"))
                    {

                        await client.SendTextMessageAsync(message.Chat.Id, $"Заходить Паскаль в бар, а там 100 тисяч Паскалів)");

                    }

                    if (message.Text.ToLower().Contains("3"))
                    {
                        foreach (var item in currRates)
                        {
                            await client.SendTextMessageAsync(message.Chat.Id, $"1 {item.txt} = {item.rate} Грн.");
                        }


                    }

                    if (message.Text.ToLower().Contains("4"))
                    {
                        List<CurrencyRate> currRate10 = currRates.FindAll(p => p.rate > 25.0);
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




