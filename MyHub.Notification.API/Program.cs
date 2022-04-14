using GlobalExceptionHandler.WebApi;
using MyHub.Notification.Domain.Exceptions;
using MyHub.Notification.Domain.SeedWork;
using MyHub.Notification.IoC;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Logging.ClearProviders();
BootStrapper.ConfigureServices(builder.Services, builder.Configuration);

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

//app.UseMiddleware<GlobalExceptionHandlerMiddleware>();

app.UseGlobalExceptionHandler(x =>
{
    x.ContentType = "application/json";
    x.ResponseBody(s => JsonConvert.SerializeObject(new
    {
        Message = "An error occurred whilst processing your request"
    }));

    x.Map<RecordNotFoundException>().ToStatusCode(StatusCodes.Status404NotFound)
       .WithBody((ex, context) => JsonConvert.SerializeObject(new
       {
           Message = ex.Message
       }));

    x.Map<SendException>().ToStatusCode(StatusCodes.Status400BadRequest)
    .WithBody((ex, context) => JsonConvert.SerializeObject(new ResponseError
    {
        Message = ex.Message,
        Results = ex.Results
    }));
});

app.Map("/error", x => x.Run(y => throw new Exception()));

app.Run();