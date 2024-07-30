using Final.EFW.Database;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using NLog;
using NLog.Config;
using Microsoft.AspNetCore.Mvc;

namespace Final
{
    public class Program
    {
        public static void Main(string[] args)
        {   
            LogManager.Configuration = new XmlLoggingConfiguration("nlog.config");
            Logger logger = LogManager.GetCurrentClassLogger();
            logger.Debug("init main");
            try
            {
                Core.DB _db = new Core.DB();
                Core.CheckDBStaticValues(_db);
                var builder = WebApplication.CreateBuilder(args);

                // Add services to the container.
                builder.Services.AddControllersWithViews();

                var app = builder.Build();

                // Configure the HTTP request pipeline.
                if (!app.Environment.IsDevelopment())
                {
                    app.UseExceptionHandler("/Home/Error");
                }
                app.UseStaticFiles();

                app.UseRouting();

                app.UseAuthorization();

                app.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                app.Run();
            }
            catch (Exception exception)
            {
                logger.Error(exception, "Stopped program because of exception");
                throw;
            }
            finally
            {
                NLog.LogManager.Shutdown();
            }
        }
    }
}
