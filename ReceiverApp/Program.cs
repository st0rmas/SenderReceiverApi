using MassTransit;
using ReceiverApp.Services;

namespace ReceiverApp;

public class Program
{
	public static void Main(string[] args)
	{
		var builder = Host.CreateApplicationBuilder(args);

		builder.Services.AddMassTransit(x =>
		{
			x.AddConsumer<MessageConsumer>();
			x.UsingRabbitMq((context, cfg) =>
			{
				cfg.ReceiveEndpoint("MessageQueue", e =>
					e.ConfigureConsumer<MessageConsumer>(context));
				cfg.ConfigureEndpoints(context);
			});
		});
		builder.Services.AddHostedService<Worker>();

		var host = builder.Build();
		host.Run();
	}
}