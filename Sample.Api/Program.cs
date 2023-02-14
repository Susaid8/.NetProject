using Microsoft.EntityFrameworkCore;
using Sample.DataAccess;

namespace Sample.Api
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

            builder.Services.AddDbContext<SampleContext>(options => 
                options.UseSqlServer(builder.Configuration.GetConnectionString("SampleContext")));

            builder.Services.AddScoped<ISampleRepository, SampleRepository>();

            var app = builder.Build();

            using(var scope = app.Services.CreateScope())
            {
                var service = scope.ServiceProvider;
                var context = service.GetRequiredService<SampleContext>();
                context.Database.EnsureCreated();
            }

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
    }
}