using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Magic.Web.Entry
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args).Inject();
            builder.Host.UseSerilogDefault();
            var app = builder.Build();
            app.Run();
        }         
    }
}
