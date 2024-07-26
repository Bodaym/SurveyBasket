using SurveyBasket.Api.Middleware;
using SurveyBasket.Api.Services;
using SurveyBasket.Middleware;
using SurveyBasket.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddKeyedTransient<IOperationTransient, WindowsOsService>(serviceKey: "windows");
builder.Services.AddKeyedTransient<IOperationTransient,MacOsServices>(serviceKey: "macOs");



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//var logger = app.Logger;

//app.Use(async (context, next) =>
//{
//    logger.LogInformation(message: "Proessing request");
//    await next(context);
//    logger.LogInformation(message: "Proessing response");

//});
app.UseCustomMiddleware();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers(); 

app.Run();
