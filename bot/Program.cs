using AngleSharp;
using AngleSharp.Dom;
using System;
using System.Collections.Generic;
using System.Threading;

namespace bot
{
    internal class Program
    {
       
        delegate string MyFunc();
        static void Main(string[] args)
        {
            
            var dict = new Dictionary<string, MyFunc>()
            {
                {"привет", BotAction.Hello },
                {"здравствуй", BotAction.Hello },
                {"здравствуйте", BotAction.Hello },
                {"добрый день", BotAction.Hello },
                {"добрый вечер", BotAction.Hello },
                {"доброе утро", BotAction.Hello },
                {"доброй ночи", BotAction.Hello },
                {"как тебя зовут?", BotAction.MyName },
                {"анекдот", BotAction.Joke },
                {"который сейчас час?", BotAction.TimeNow },
                {"сколько времени?", BotAction.TimeNow },
                {"который час?", BotAction.TimeNow }
            };

            Thread t = new Thread(new ThreadStart(BotAction.Hello1));
            t.Start();
            string str = Input.ConsoleInput();
            while (str != "пока" && str != "до свидания")
            {
                if (dict.ContainsKey(str))
                {
                    Output.ConsoleOutput(dict[str]());
                }
                else if (str.Contains("анекдот"))
                {
                    Output.ConsoleOutput(dict["анекдот"]());
                }
                else
                {
                    Output.ConsoleOutput(BotAction.Aphorisms());
                }
                str = Input.ConsoleInput();
            }

           Output.ConsoleOutput("До новых встреч, дорогой собеседник!");
        }
            
    }
}
