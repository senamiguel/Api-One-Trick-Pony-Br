using Api_One_Trick_Pony_Br.Data;
using Api_One_Trick_Pony_Br.Repository;
using Api_One_Trick_Pony_Br.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApiContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("TestContext") ?? throw new InvalidOperationException("Connection string 'TestContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<PonyRepository>();
builder.Services.AddScoped<PlatformRepository>();
builder.Services.AddScoped<SocialMediaRepository>();
builder.Services.AddScoped<CommentRepository>();
builder.Services.AddScoped<AccountRepository>();
builder.Services.AddSwaggerGen();

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

app.MapPonyEndpoints();

app.MapPlatformEndpoints();

app.MapAccountEndpoints();

app.MapCommentEndpoints();

app.MapSocialMediaEndpoints();

app.Run();
