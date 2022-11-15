using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

var builder = WebApplication.CreateBuilder(args);

var  MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder =>
                      {
                          builder.AllowAnyMethod()
                                .AllowAnyHeader()
                                .AllowCredentials()
                                .SetPreflightMaxAge(TimeSpan.FromSeconds(2520));
                      });
});
ConfigurationManager configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region context db
// builder.Services.AddDbContext<MCFContext>
builder.Services.AddDbContext<MCFContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Conn")));

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseSession();
app.UseStaticFiles();
app.UseCookiePolicy();
app.UseAuthentication();

app.UseCors(MyAllowSpecificOrigins);

app.MapControllers();

app.Run();


