using RPA.Alura.Infrastructure.Di;
using RPA.Alura.Services.Di;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Host.ConfigureServices((hostContext, services) =>
{
    var config = hostContext.Configuration;
    services
        .AddAutoMapper()
        .AddRepositories()
        .AddServices()
        .AddFacades()
        .AddRPAContext(config);
});

var app = builder.Build();

app.AddMigration();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();