﻿using System;
using NServiceBus;
using NServiceBus.Features;

class Program
{
    static void Main()
    {
        BusConfiguration busConfiguration = new BusConfiguration();
        busConfiguration.EndpointName("Samples.Gateway.RemoteSite");
        busConfiguration.EnableInstallers();
        busConfiguration.EnableFeature<Gateway>();
        busConfiguration.UsePersistence<InMemoryPersistence>();

        using (IBus bus = Bus.Create(busConfiguration).Start())
        {
            Console.WriteLine("\r\nPress any key to stop program\r\n");
            Console.ReadKey();
        }
    }
}

