﻿using System;
using Amazon;
using Amazon.CloudWatchLogs;
using Amazon.Runtime;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Json;
using Serilog.Sinks.AwsCloudWatch;

namespace API.Infrastructure.Extensions {
    public static class LoggerOptions {
        public static void AddLoggerOptions(this IServiceCollection services, IWebHostEnvironment environment, IConfiguration configuration) {

            if (environment.IsDevelopment()) {
                Log.Logger = new LoggerConfiguration()
                    .ReadFrom.Configuration(configuration)
                    .CreateLogger();

            } else if (environment.IsEnvironment("QA")) {
                var awsConfiguration = configuration.GetSection("AWS");
                var options = new CloudWatchSinkOptions
                {
                    LogGroupName = $"nna-api-{environment.EnvironmentName}",
                    TextFormatter = new JsonFormatter("."),
                    MinimumLogEventLevel =
                        (LogEventLevel)Enum.Parse(typeof(LogEventLevel), awsConfiguration["MinimumLogEventLevel"]),
                    CreateLogGroup = true,
                    LogStreamNameProvider = new DefaultLogStreamProvider(),
                    RetryAttempts = byte.Parse(awsConfiguration["RetryAttempts"])
                };
                var client = new AmazonCloudWatchLogsClient(
                    //todo: move credentials to some aws
                    new BasicAWSCredentials(awsConfiguration["AccessKey"], awsConfiguration["SecretKey"]),
                    RegionEndpoint.EUCentral1);

                Log.Logger = new LoggerConfiguration()
                    .WriteTo.AmazonCloudWatch(options, client)
                    .CreateLogger();
            }
        }
    }
}
