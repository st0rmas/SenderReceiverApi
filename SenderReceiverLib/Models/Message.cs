namespace SenderReceiverLib.Models;

public record class Message
{
	public required string Value { get; init; }
}