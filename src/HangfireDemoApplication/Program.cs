using Hangfire;
using Hangfire.Dashboard;
using Hangfire.SqlServer;
using HangfireDemoApplication.Domain;
using HangfireDemoApplication.Infra.Repositories.ReadRepositories.ProductReadRepositories;
using HangfireDemoApplication.Infra.Repositories.WriteRepositories.ProductWriteRepositories;
using HangfireDemoApplication.Services;
using HangfireDemoApplication.Services.Contract;
using HangfireDemoBackground.BackgroundJobs.Contracts;
using HangfireDemoBackground.CustomLoggers;
using HangfireDemoBackground.Wrappers;
using HangfireDemoBackground.Wrappers.Contracts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region [ DI ]

builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddScoped<IProductReadRepository, ProductReadRepository>();
builder.Services.AddScoped<IProductWriteRepository, ProductWriteRepository>();

builder.Services.AddScoped<IFeeWrapper, FeeWrapper>();
builder.Services.AddScoped<IFeeBackgroundJob, FeeBackgroundJob>();

#endregion [ DI ]

#region [ Hangfire Services ]

builder.Services.AddHangfire(configuration => configuration
    .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
    .UseSimpleAssemblyNameTypeSerializer()
    .UseRecommendedSerializerSettings()
        .UseSqlServerStorage(builder.Configuration.GetConnectionString("HangfireConnection"), new SqlServerStorageOptions
        {
            TryAutoDetectSchemaDependentOptions = false // Defaults to `true`
        })
        .UseLogProvider(new CustomLogProvider()));

builder.Services.AddHangfireServer();

#endregion [ Hangfire Services ]


var app = builder.Build();

#region [ Hangfire ]

app.UseHangfireDashboard("/hangfire", new DashboardOptions
{
    IsReadOnlyFunc = (DashboardContext context) => true
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