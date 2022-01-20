using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using System;
using System.IO;
using System.Runtime.InteropServices;

namespace ModernMilkmanDemoApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHost(args).Run();
        }

        public static IWebHost CreateWebHost(string[] args)
        {
            return WebHost
                .CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, builder) =>
                {
                    builder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                        .AddJsonFile($"appsettings.{context.HostingEnvironment.EnvironmentName}.json", optional: true, reloadOnChange: true)
                        .AddEnvironmentVariables();

                    Log.Logger = CreateLogger(context);

                    Log.Information($@"Starting...
Environment:            {context.HostingEnvironment.EnvironmentName}
FrameworkDescription:   {RuntimeInformation.FrameworkDescription}
OSDescription:          {RuntimeInformation.OSDescription}
OSArchitecture:         {RuntimeInformation.OSArchitecture}
ProcessArchitecture:    {RuntimeInformation.ProcessArchitecture}
");

                })
                .ConfigureLogging(builder => { builder.ClearProviders(); })
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseKestrel()
                .UseStartup<Startup>()
                .Build();
        }

        private static Serilog.ILogger CreateLogger(WebHostBuilderContext hostContext)
        {
            var loggerConfig = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .Enrich.WithProperty("API", hostContext.HostingEnvironment.ApplicationName)
                .Enrich.WithProperty("env", hostContext.HostingEnvironment.EnvironmentName)
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .MinimumLevel.Override("System", LogEventLevel.Information)
                .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
                .MinimumLevel.Information();

            loggerConfig
                .WriteTo.Console()
                .WriteTo.File($"{AppDomain.CurrentDomain.BaseDirectory}/Logs/{hostContext.HostingEnvironment.ApplicationName}.log");

            return loggerConfig.CreateLogger();
        }
    }

}
