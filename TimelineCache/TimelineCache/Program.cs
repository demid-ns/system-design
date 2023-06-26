using Microsoft.EntityFrameworkCore;
using TimelineCache.Data;
using TimelineCache.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddScoped<ITimelineService, TimelineService>()
    .AddScoped<IUserRepository, UserRepository>()
    .AddScoped<ITimelineValidationService, TimelineValidationService>();


builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("TimelineCacheConn"));
});

var app = builder.Build();

DbInit.Initialize(app);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
