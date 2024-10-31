using Pitstop.CustomerSupportService.Events;
using Pitstop.CustomerSupportService.Repositories;

namespace Pitstop.CustomerSupportService;

public class EventHandlerWorker : IHostedService, IMessageHandlerCallback
{
    private readonly ICustomerSupportRepository _repo;
    private readonly IMessageHandler _messageHandler;

    public EventHandlerWorker(IMessageHandler messageHandler, ICustomerSupportRepository repo)
    {
        _messageHandler = messageHandler;
        _repo = repo;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _messageHandler.Start(this);
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _messageHandler.Stop();
        return Task.CompletedTask;
    }

    public async Task<bool> HandleMessageAsync(string messageType, string message)
    {
        Log.Information("Received message of type {MessageType}", messageType);
        
        var messageObject = MessageSerializer.Deserialize(message);
        try
        {
            switch (messageType)
            {
                case "RepairOrderRejected":
                    return await HandleAsync(messageObject.ToObject<RepairOrderRejected>());
            }
        }
        catch (Exception ex)
        {
            var messageId = messageObject.Property("MessageId") != null ? messageObject.Property("MessageId").Value<string>() : "[unknown]";
            Log.Error(ex, "Error while handling {MessageType} message with id {MessageId}", messageType, messageId);
        }

        // always acknowledge message - any errors need to be dealt with locally.
        return true;
    }
    
    private async Task<bool> HandleAsync(RepairOrderRejected @event)
    {
        Log.Information("Register Repair Order Rejection: {RejectOrderId}, {RejectedAt}, {RejectReason}",
            @event.RepairOrderId, @event.RejectedAt, @event.RejectReason);
    
        var rejection = new Rejection(@event.RepairOrderId, @event.RejectReason, @event.RejectedAt);

        Log.Information("Register rejection: {RepairOrderId}, {RejectReason}, {RejectedAt}",
            rejection.RepairOrderId, rejection.RejectReason, rejection.RejectedAt);

        await _repo.RegisterRejectionAsync(rejection);
    
        return true;
    }
}