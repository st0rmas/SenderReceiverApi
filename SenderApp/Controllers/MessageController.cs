using MassTransit;
using Microsoft.AspNetCore.Mvc;
using SenderReceiverLib.Models;

namespace SenderApp.Controllers;

[ApiController]
[Route("/message")]
public class MessageController : ControllerBase
{
	private readonly IBus _bus;
	private readonly ILogger<MessageController> _logger;

	public MessageController(IBus bus, ILogger<MessageController> logger)
	{
		_bus = bus;
		_logger = logger;
	}
	
	[HttpPost]
	public async Task<IActionResult> SendMessage(Message message)
	{
		await _bus.Publish(message);
		_logger.LogInformation($"Сообщение отправлено приложению Б");
		return Ok();
	}
}