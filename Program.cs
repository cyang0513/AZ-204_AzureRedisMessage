using System;
using StackExchange.Redis;

namespace AzureRedisMessage
{
   class Program
   {
      static void Main(string[] args)
      {
         Console.WriteLine("Redis Message publisher.");

         var redisClient = ConnectionMultiplexer.Connect("chyaredis.redis.cache.windows.net:6380,password=Q6UOzzdNSIiQa3sgw6znCeHINpfXKAStPkIEinjXths=,ssl=True,abortConnect=False");
         var redisDb = redisClient.GetDatabase();

         while (true)
         {
            Console.WriteLine("Type your message to publish (Type Q to quit):");

            var msg = Console.ReadLine();

            if (msg == "Q")
            {
               break;
            }

            redisDb.Publish("redisChannel", msg);
         }

      }
   }
}
