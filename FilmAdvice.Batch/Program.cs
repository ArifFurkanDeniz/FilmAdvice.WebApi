using FilmAdvice.Batch.Configuration;
using FilmAdvice.Batch.Jobs;
using LuxuryResume.Batch.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Quartz;
using System;
using System.IO;

namespace FilmAdvice.Batch
{
    class Program
    {
        public static IConfigurationRoot configuration;
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {

                    // Build configuration
                    configuration = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                        .AddJsonFile("appsettings.json", false)
                        .Build();

                    //DbContext
                    services.AddMyDbContext(configuration);
                    //Log
                    services.AddSeriLog(configuration);
                    //Service
                    services.AddMyServices();

                    services.AddQuartz(q =>
                    {
                        q.UseMicrosoftDependencyInjectionScopedJobFactory();

                        // Create a "key" for the job
                        var jobKey = new JobKey("FilmPullJob");

                        // Register the job with the DI container
                        q.AddJob<FilmPullJob>(opts => opts.WithIdentity(jobKey));

                        // Create a trigger for the job
                        q.AddTrigger(opts => opts
                            .ForJob(jobKey) // link to the HelloWorldJob
                            .WithIdentity("FilmPullJob-trigger") // give the trigger a unique name
                           // .WithCronSchedule("0 0 * ? * * *")); // every hour
                            .WithCronSchedule(" 0 0/1 * * * ?")); // every minute

                    });
                    services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);
                    // ...
                });
    }
}
