using Infrastrecture;
using MediatR;
using Microsoft.Data.SqlClient;
using Polly;
using Polly.Retry;

namespace user_management
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddinfrastrectureSevices(builder.Configuration);
            builder.Services.AddMediatR(typeof(Program).Assembly);
            builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

          

            // Ajoutez la politique de répétition pour gérer les erreurs de connexion à la base de données
            builder.Services.AddSingleton(sp => CreateRetryPolicy());

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }

        // Définition de la politique de répétition
        private static RetryPolicy CreateRetryPolicy()
        {
            return Policy
                .Handle<SqlException>() // À ajuster en fonction de vos exceptions
                .WaitAndRetry(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
        }
    }
}
