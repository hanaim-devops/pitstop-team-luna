var host = Host
    .CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.UseRabbitMQMessageHandler(hostContext.Configuration);

        services.AddTransient<ICustomerSupportRepository>((svc) =>
        {
            var sqlConnectionString = hostContext.Configuration.GetConnectionString("CustomerSupportCN");
            return new SqlServerCustomerSupportRepository(sqlConnectionString);
        });
        
        services.AddHostedService<EventHandlerWorker>();
    })
    .UseSerilog((hostContext, loggerConfiguration) =>
    {
        loggerConfiguration.ReadFrom.Configuration(hostContext.Configuration);
    })
    .UseConsoleLifetime()
    .Build();

await host.RunAsync();