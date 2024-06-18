using MassTransit;
using SenderReceiverLib.Models;

namespace ReceiverApp.Services;

public class MessageConsumer: IConsumer<Message>
{
	private readonly ILogger<MessageConsumer> _logger;

	public MessageConsumer(ILogger<MessageConsumer> logger)
	{
		_logger = logger;
	}

	public Task Consume(ConsumeContext<Message> context)
	{
		var message = context.Message;
		_logger.LogInformation($"Сообщение получено. Значение: {message.Value}");
		return Task.CompletedTask;
	}
}