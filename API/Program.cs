using API.Middleware;
using Core.Interfaces.Repository;
using Infrastructure.Data;
using Infrastructure.Data.Seeding;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

builder.Services.AddDbContext<AppDbContext>(options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
        options.EnableSensitiveDataLogging(true);
    }
);

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseStatusCodePagesWithReExecute("/errors/{0}");

app.UseHttpsRedirection();
 
app.UseAuthorization();

app.UseStaticFiles();

app.MapControllers();

await Migrate(app);
 
app.Run();  

async Task Migrate(WebApplication application)
{
    try
    {
        using var scope = application.Services.CreateScope();
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<AppDbContext>();
        await Seed.SeedData(context);
    }
    catch (Exception e)
    {
        application.Logger.LogError(e, "An error occured during migration");
    }
}