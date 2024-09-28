var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
builder.Services.RegisterDatabase(builder.Configuration);
builder.Services.RegisterTemplateApplication();
var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseTemplate();

if (app.Environment.IsDevelopment())
{
    app.UseCors(o => { o.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin(); });
}
else
{
    // Add support for PROD CORS
}

app.Run();

