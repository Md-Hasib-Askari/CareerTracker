using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Add DbContext
builder.Services.AddDbContext<CareerTrackerDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("BGConn")));


// Add Infrastructure and Application services
builder.Services.AddApplication();
builder.Services.AddInfrastructure();

// Add Background services
builder.Services.AddHostedService<JobFetchWorker>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();


app.Run();
