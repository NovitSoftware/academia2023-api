using Microsoft.EntityFrameworkCore;
using NovitSoftware.Academia.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("AcademiaDb");

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped<DbContext, AppDbContext>();

var contextBuilderOptions = new DbContextOptionsBuilder<AppDbContext>();
contextBuilderOptions.UseSqlServer(connectionString);
var context = new AppDbContext(contextBuilderOptions.Options);
context.Database.EnsureCreated();

builder.Services.AddCors(options => options.AddPolicy(name: "NovitSoftware",
    policy =>
    {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    }));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("NovitSoftware");

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
