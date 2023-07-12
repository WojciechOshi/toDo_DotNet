using to_do.Persistance;
using ToDo;

namespace to_do
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddSingleton<IDBMock, DbMock>();
            builder.Services.AddSingleton<IDBCreator, DbCreator>();

            builder.Services.AddTransient<ISQLiteConnectionFactory, SQLiteConnectionFactory>();

            var serviceProvider = builder.Services.BuildServiceProvider();

            using (var scope = serviceProvider.CreateScope())
            {
                var dbCreator = scope.ServiceProvider.GetRequiredService<IDBCreator>();
                dbCreator.CreateDatabase();
            }

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller}/{action=Index}/{id?}");

            app.MapFallbackToFile("index.html");

            app.Run();
        }
    }
}