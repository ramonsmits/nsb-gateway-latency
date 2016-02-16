using System;
using System.Diagnostics;
using NServiceBus;
using Shared;

#region PriceUpdatedHandler
public class PriceUpdatedHandler : IHandleMessages<PriceUpdated>
{
    IBus bus;

    public PriceUpdatedHandler(IBus bus)
    {
        this.bus = bus;
    }

    public void Handle(PriceUpdated message)
    {
        var ticks = Stopwatch.GetTimestamp() - message.SentAt;
        var duration = ticks * 1000 / Stopwatch.Frequency;
        Console.WriteLine("Duration: {0}ms", duration);

        string messageHeader = bus.GetMessageHeader(message, Headers.OriginatingSite);
        Console.WriteLine("Price update for product: {0} received. Going to reply over channel: {1}", message.ProductId, messageHeader);

        bus.Reply(new PriceUpdateAcknowledged
        {
            BranchOffice = "RemoteSite"
        });
    }
}

#endregion