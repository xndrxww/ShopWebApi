using Shop.Application;
using Shop.Application.Common.Mappings;
using Shop.Application.Interfaces;
using Shop.Database;
using System.Reflection;

namespace Shop.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            app.MapGet("/", () => "Hello World!");

            using (var scope = app.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                try
                {
                    var context = serviceProvider.GetRequiredService<ShopDbContext>();
                    DbInitializer.Initialize(context);
                }
                catch (Exception)
                {

                    throw;
                }
            }

            builder.Services.AddAutoMapper(config =>
            {
                config.AddProfile(new AssemblyMappingProfiles(Assembly.GetExecutingAssembly()));
                config.AddProfile(new AssemblyMappingProfiles(typeof(IShopDbContext).Assembly));
            });

            builder.Services.AddApplication();
            builder.Services.AddPersistence(builder.Configuration);
            builder.Services.AddCors(option =>
            {
                //Для теста
                option.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                    policy.AllowAnyOrigin();
                });
            });

            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseCors("AllowAll");
            app.Run();
            app.UseEndpoints(endPoints =>
            {
                endPoints.MapControllers();
            });
        }
    }
}