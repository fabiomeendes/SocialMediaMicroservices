using AwesomeSocialMedia.Newsfeed.API.Consumers;
using AwesomeSocialMedia.Newsfeed.API.Core.Repositories;
using AwesomeSocialMedia.Newsfeed.API.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHostedService<PostCreatedConsumer>();
builder.Services.AddHostedService<UserUpdatedConsumer>();
builder.Services.AddSingleton<IUserNewsfeedRepository, UserNewsfeedRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
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

app.Run();

