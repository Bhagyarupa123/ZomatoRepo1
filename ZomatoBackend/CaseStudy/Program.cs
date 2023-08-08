using CaseStudy.Entities;
using CaseStudy.Service;
using Microsoft.EntityFrameworkCore;

namespace CaseStudy
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connection = builder.Configuration.GetConnectionString("ZomatoConnection");
            builder.Services.AddTransient<IUserService, UserService>();
            builder.Services.AddTransient<IRecipeService, RecipeService>();
            builder.Services.AddTransient<ICartService, CartService>();
            builder.Services.AddTransient<IOrderService , OrderService>();
            builder.Services.AddCors(c=>c.AddPolicy("MyPolicy",options=>options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));
            builder.Services.AddDbContext<ZomatoDBContext>(options => options.UseSqlServer(connection));
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("MyPolicy");

            app.UseAuthentication();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}