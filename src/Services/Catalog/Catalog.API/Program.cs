var builder = WebApplication.CreateBuilder(args);

//Add services

var app = builder.Build();

//Configure HTTP Req Pipeline
//app.MapGet("/", () => "Hello World!");

app.Run();
