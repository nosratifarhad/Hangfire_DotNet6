using Hangfire;
using Hangfire.SqlServer;
using HangfireDemoApplication.Domain;
using HangfireDemoApplication.Infra.Repositories.ReadRepositories.PayrollReadRepositories;
using HangfireDemoApplication.Infra.Repositories.WriteRepositories.PayrollWriteRepositories;
using HangfireDemoApplication.Services;
using HangfireDemoApplication.Services.Contract;
using HangfireDemoBackground.BackgroundJobs;
using HangfireDemoBackground.BackgroundJobs.Contracts;
using HangfireDemoBackground.CustomLoggers;
using HangfireDemoBackground.Wrappers;
using HangfireDemoBackground.Wrappers.Contracts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region [ DI ]

builder.Services.AddScoped<IPayrollService, PayrollService>();

builder.Services.AddScoped<IPayrollReadRepository, PayrollReadRepository>();
builder.Services.AddScoped<IPayrollWriteRepository, PayrollWriteRepository>();

builder.Services.AddScoped<IPayrollCalculatorJob, PayrollCalculatorJob>();
builder.Services.AddScoped<IPayrollDirectDepositJob, PayrollDirectDepositJob>();
builder.Services.AddScoped<IPayrollWrapper, PayrollWrapper>();

#endregion [ DI ]

#region [ Hangfire Services ]

builder.Services.AddHangfire(configuration => configuration
    .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
    .UseSimpleAssemblyNameTypeSerializer()
    .UseRecommendedSerializerSettings()
        .UseSqlServerStorage(builder.Configuration.GetConnectionString("HangfireConnection"), new SqlServerStorageOptions
        {
            TryAutoDetectSchemaDependentOptions = false
        })
        .UseLogProvider(new CustomLogProvider()));

builder.Services.AddHangfireServer();

#endregion [ Hangfire Services ]

var app = builder.Build();

#region [ Hangfire ]

//var options = new BackgroundJobServerOptions
//{
//    ServerName = String.Format(
//        "{0}.{1}",
//        Environment.MachineName,
//        Guid.NewGuid().ToString())
//};

//app.UseHangfireServer(options);

app.UseHangfireDashboard("/hangfire", new DashboardOptions
{
    //IsReadOnlyFunc = (DashboardContext context) => true
});

#endregion [ Hangfire ]

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseHttpsRedirection();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapHangfireDashboard();
});

app.Run();
