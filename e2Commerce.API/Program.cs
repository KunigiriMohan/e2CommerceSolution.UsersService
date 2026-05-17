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

var app = builder.Build();  

app.UseExceptionHandlingMiddleware();
app.UseRouting();
app.UseAuthentication();


app.MapControllers();

app.MapGet("/", () => "Hello World!");

app.Run();
