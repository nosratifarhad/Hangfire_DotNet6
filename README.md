## First Install Packages :
```
dotnet add package Hangfire.AspNetCore
dotnet add package Hangfire.Core
dotnet add package Hangfire.SqlServer
```
### Add Database In Sql Server With Name "Hangfire_DB" And Add To Connection String 
```json
"ConnectionStrings": {
    "HangfireConnection": "Server=(localdb)\\MSSqlLocalDb;Database=Hangfire_DB;Integrated Security=SSPI;"
  },
```
## Add Hangfire to the File Program.cs like me .
### Now You Can Access To Hangfire Dashboard In Address "http://localhost:0000/hangfire"
```csharp
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
```
### Now If You Need Enqueue Job Just enough User This Method .
```csharp
public async Task EnqueueJob()
{
    string jobId =
         BackgroundJob.Enqueue("calculatefeebyenqueuejob_enqueue_type",
        () => _payrollWrapper.CalculatePayrollAsync());

    await Task.Delay(1);
}
```
### Now If You Need Schedule Job Just enough User This Method .
### You Can Fix Run Time From "TimeSpan.FromSeconds(10))"
```csharp
public async Task ScheduleJob()
{
    string jobId =
        BackgroundJob.Schedule("calculatefeebyschedulejob_schedule_type",
     () => _payrollWrapper.CalculatePayrollAsync(),
     TimeSpan.FromSeconds(10));

    await Task.Delay(1);
}
```
### Now If You Need Recurring Job Just enough User This Method .
### You Can Fix Daily From "Cron.Daily" And "Cron.Yearly()" And "string cronExp = "* * */8 * *";" Like This
```csharp
public async Task RecurringJob()
{
    //Cron.Daily
    //Cron.Yearly()
    //string cronExp = "* * */8 * *";

    Hangfire.RecurringJob.AddOrUpdate("calculatefeebyrecurring_addorupdate_type",
        () => _payrollWrapper.CalculatePayrollAsync(),
        Cron.Daily);

    await Task.Delay(1);
}
```
### You Can Remove All Recurring Job  .
```csharp
public async Task RecurringRemoveIfExists()
{
    using (var connection = JobStorage.Current.GetConnection())
    {
        //JobData jobData13 = connection.GetJobData("29");
        //BackgroundJob.Delete("29");

        foreach (var recurringJob in connection.GetRecurringJobs())
        {
            Hangfire.RecurringJob.RemoveIfExists(recurringJob.Id);
        }
    }

    await Task.Delay(1);
}
```
## Apis For Job Manages .
![My Remote Image](https://github.com/nosratifarhad/Hangfire_DotNet6/blob/main/img/Annotation5.jpg)

## Home Page Hangfire: Show Your Activity .
![My Remote Image](https://github.com/nosratifarhad/Hangfire_DotNet6/blob/main/img/Annotation3.jpg)

## Enqueued Jobs And you can All Enqueue And Schedule Jobs .
![My Remote Image](https://github.com/nosratifarhad/Hangfire_DotNet6/blob/main/img/Annotation2.jpg)

## Got To One Of Queues and you can remove jobs.
![My Remote Image](https://github.com/nosratifarhad/Hangfire_DotNet6/blob/main/img/Annotation1.jpg)

## Scheduled Jobs And you can Run Jobs .
![My Remote Image](https://github.com/nosratifarhad/Hangfire_DotNet6/blob/main/img/Annotation.jpg)

## Got To One Of Scheduled Jobs And You Can See Job State And Code .
![My Remote Image](https://github.com/nosratifarhad/Hangfire_DotNet6/blob/main/img/Annotation4.jpg)
