using MassTransit;

namespace SenderApp;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllers();
        builder.Services.AddMassTransit(x =>
        { 
            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.ConfigureEndpoints(context);
            });
        });
        
        var app = builder.Build();
        app.MapControllers();
        
        app.Run();
    }
}
