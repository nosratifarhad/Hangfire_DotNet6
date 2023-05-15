using HangfireWebApplication.Domain;
using HangfireWebApplication.Infra.Repositories.ReadRepositories.ProductReadRepositories;
using HangfireWebApplication.Infra.Repositories.WriteRepositories.ProductWriteRepositories;
using HangfireWebApplication.Services.Contract;
using HangfireWebApplication.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region [ IOC ]

#region [ Application ]

builder.Services.AddScoped<IProductService, ProductService>();

#endregion [Application]

#region [ Infra - Data ]

builder.Services.AddScoped<IProductReadRepository, ProductReadRepository>();
builder.Services.AddScoped<IProductWriteRepository, ProductWriteRepository>();

#endregion [ Infra - Data EventSourcing ]

#endregion [ IOC ]

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
