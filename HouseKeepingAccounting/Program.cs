using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace HouseKeepingAccounting
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
            
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseUrls("http://*:8081")
                .UseIISIntegration()
                .UseStartup<Startup>();
    }
}
