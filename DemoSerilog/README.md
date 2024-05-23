### This project demo using logging with serilog?

1. Download package: Serilog in nuget
 
2. Config in program
//config serilog
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console() //log to console
    .WriteTo.File("logs/myLoggingInformation-.txt", rollingInterval: RollingInterval.Day) //log to file
    .CreateLogger();

3. Put the Log into the controller
//Logging with serilog here
Log.Information("Weather forecast => {@result}", rersult);

---------------------
### Logging setting read from configuration:

1. program.cs
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration).CreateBootstrapLogger();  //logging read from json file

2. configuration.json
"Serilog": {
    "Using": [ "Serilog.Sinks.Console", "Serilog.Sinks.File" ],
    "WriteTo": [
      {
        "Name": "Console",
      },
      {
        "Name": "File",
        "Args": {
          "path": "logs/configlog-.txt",
          "rollingInterval":  "Day"
        }
      }
    ]
  }


----------------
### Serilog request logging:

1. Program.cs
//serilog requestlogging
builder.Host.UseSerilog();

//config middleware for serilog
app.UseSerilogRequestLogging();


#### note: increase response time