using DotNetEnv;

IHost host = Host
    .CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.UseRabbitMQMessageHandler(hostContext.Configuration);

        services.AddTransient<INotificationRepository>((svc) =>
        {
            var sqlConnectionString = hostContext.Configuration.GetConnectionString("NotificationServiceCN");
            return new SqlServerNotificationRepository(sqlConnectionString);
        });

        services.AddTransient<IEmailNotifier>((svc) =>
        {
            var mailConfigSection = hostContext.Configuration.GetSection("Email");
            string mailHost = mailConfigSection["Host"];
            int mailPort = Convert.ToInt32(mailConfigSection["Port"]);
            string mailUserName = mailConfigSection["User"];
            string mailPassword = mailConfigSection["Pwd"];
            return new SMTPEmailNotifier(mailHost, mailPort, mailUserName, mailPassword);
        });
        
        services.AddTransient<ISlackMessenger>((svc) =>
        {
            Env.Load();
            var webhookUrl = Environment.GetEnvironmentVariable("PITSTOP_APP");
            
            return new SlackMessenger("https://hooks.slack.com/services/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");
        });
        
        services.AddHostedService<NotificationWorker>();
    })
    .UseSerilog((hostContext, loggerConfiguration) =>
    {
        loggerConfiguration.ReadFrom.Configuration(hostContext.Configuration);
    })
    .UseConsoleLifetime()
    .Build();

await host.RunAsync();