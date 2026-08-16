var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCarter();


var app = builder.Build();

// Add Middlewares     
app.Run();