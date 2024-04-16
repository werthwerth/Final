using Final.EFW.Database;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Final
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Core.DB _db = new Core.DB();
            Core.CheckDBStaticValues( _db );
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
    }
}
