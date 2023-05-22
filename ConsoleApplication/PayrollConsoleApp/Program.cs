using Hangfire;
using Hangfire.SqlServer;
using HangfireDemoConsoleApplication.BackgroundJobs;
using HangfireDemoConsoleApplication.BackgroundJobs.Contracts;
using HangfireDemoConsoleApplication.CustomLoggers;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PayrollConsoleApp.Services;
using PayrollConsoleApp.Services.Contracts;

public class Program
{
    public static void Main(string[] args)
    {
        var app =
            WebApplication.CreateBuilder(new WebApplicationOptions()
            { ApplicationName = "PayrollConsoleApp", EnvironmentName = "Development" }).Build();

        string connectionString = app.Configuration.GetConnectionString("HangfireConnection");

        var configur = CreateHostBuilder(args, connectionString).Build();

        app.UseHangfireDashboard("/hangfire", new DashboardOptions
        {
            //IsReadOnlyFunc = (DashboardContext context) => true
        });

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapHangfireDashboard();
        });


        configur.Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args, string connectionString) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                #region AddServices

                services.AddSingleton<IPayrollService, PayrollService>();
                services.AddSingleton<IPayrollCalculatorJob, PayrollCalculatorJob>();
                services.AddSingleton<IPayrollDirectDepositJob, PayrollDirectDepositJob>();

                #endregion AddServices

                //#region [ Hangfire Services ]

                //services.AddHangfire(configuration => configuration
                //    .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
                //    .UseSimpleAssemblyNameTypeSerializer()
                //    .UseRecommendedSerializerSettings()
                //        .UseSqlServerStorage(connectionString,
                //        new SqlServerStorageOptions
                //        {
                //            TryAutoDetectSchemaDependentOptions = false // Defaults to `true`
                //        })
                //        .UseLogProvider(new CustomLogProvider()));

                //services.AddHangfireServer();

                //#endregion [ Hangfire Services ]
            });


}