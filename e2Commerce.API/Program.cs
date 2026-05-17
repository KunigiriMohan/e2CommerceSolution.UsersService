using eCommerce.Infrastructure;
using eCommerce.Core;
using e2Commerce.API.Middlewares;
using eCommerce.Core.Mappers;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure();
builder.Services.AddCore();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.
    Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
});

builder.Services.AddAutoMapper(cfg => { },
    typeof(ApplicationUserMappingProfile).Assembly);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
    });
});

var app = builder.Build();  

app.UseExceptionHandlingMiddleware();
app.UseRouting();
app.UseAuthentication();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors();

app.MapControllers();

app.MapGet("/", () => "Hello World!");

app.Run();
