using AngleSharp;
using AngleSharp.Dom;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace bot
{
    internal class Program
    {
       
        delegate void MyFunc();
        static bool flag = true;
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
           
            BotAction.Hello();
            ConcurrentQueue<MyFunc> cq = new ConcurrentQueue<MyFunc>();
            Thread checkQueue = new Thread(new ParameterizedThreadStart(StartReading));
            checkQueue.Start(cq);
            
            string str = Input.ConsoleInput();
            while (str != "пока" && str != "до свидания")
            {
                if (dict.ContainsKey(str))
                {
                    cq.Enqueue(dict[str]);
                }
                else if (str.Contains("анекдот"))
                {
                    cq.Enqueue(dict["анекдот"]);
                }
                else
                {
                    cq.Enqueue(BotAction.Aphorisms);
                }
                Console.WriteLine(cq.Count);
                str = Input.ConsoleInput();
            }
            flag = false;
           Console.WriteLine("До новых встреч, дорогой собеседник!");
        }
       
        static void StartReading(Object object1)
        {
            var cq = (ConcurrentQueue<MyFunc>)object1;
            
            while (flag)
            {
                
                Task.Delay(5000).Wait();
                if (cq != null)
                {
                    if (cq.TryDequeue(out MyFunc obj))
                    {
                        Console.WriteLine("В очереди что-то есть");
                        obj();
                    }
                    else
                    {
                        Console.WriteLine("Я попытался извлечь из очереди, но ничего не получилось(");
                    }
                }
                else
                {
                    Console.WriteLine("Всё ещё null");
                }
                


            }

        }
    }
}
