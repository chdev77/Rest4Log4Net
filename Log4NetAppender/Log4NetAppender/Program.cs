using System;
using System.Collections.Generic;

namespace Log4NetAppender
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting...press any key");
            Console.ReadKey();

            var msg = LoadMessages();

            try
            {
                msg.ForEach(m => {
                    Logger.Activity(m);
                });
                
                throw new Exception("Ouch an exception!!!");
            }
            catch (Exception ex)
            {
                Logger.Exception("This is a test exception", ex);
            }

            Console.WriteLine("Done! press any key");
            Console.ReadKey();
        }

        private static List<string> LoadMessages()
        {
            var msg = new List<string>();

            msg.Add("This is my story");
            msg.Add("My name is CSharp");
            msg.Add("I live in your PC");
            msg.Add("I love RAM and CPU");
            msg.Add("I hate exceptions!");
            msg.Add("I was slower when I was young");
            msg.Add("Today I am very fast (sometimes)");
            msg.Add("I want to be super duper fast, please!");
            msg.Add("This is the end of my story");
            msg.Add("Sincerely, CSharp");

            return msg;
        }
    }
}
