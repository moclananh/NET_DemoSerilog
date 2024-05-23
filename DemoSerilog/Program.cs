using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//config serilog
/*Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console() //log into console
    .WriteTo.File("logs/myLoggingInformation-.txt", rollingInterval: RollingInterval.Day) //log into a file txt
    .CreateLogger();*/

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration).CreateBootstrapLogger();  //logging read from json file

//serilog requestlogging
builder.Host.UseSerilog();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//config middleware for serilog
app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
