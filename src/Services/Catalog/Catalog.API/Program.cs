var builder = WebApplication.CreateBuilder(args);

var assembly = typeof(Program).Assembly;

builder.Services.AddMediatR(configuration =>
    configuration.RegisterServicesFromAssembly(assembly)
);

builder.Services.AddCarter();


builder.Services.AddMarten(opts => { opts.Connection(builder.Configuration.GetConnectionString("Database")!); })
    .UseLightweightSessions();


var app = builder.Build();

app.MapCarter();

app.Run();