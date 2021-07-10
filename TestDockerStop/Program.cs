using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace TestDockerStop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // SIGTERM
            System.Runtime.Loader.AssemblyLoadContext.Default.Unloading += (ctx) => {
                System.Console.WriteLine($"[{T()}] === SIGTERM");
            };

            // SIGQUIT
            Console.CancelKeyPress += (sender, e) =>
            {
                System.Console.WriteLine($"[{T()}] === SIGQUIT");
            };

            CreateHostBuilder(args).Build().Run();
        }

        public static string T()
        {
            return DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}