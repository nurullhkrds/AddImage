using Microsoft.EntityFrameworkCore;
using StudentApgi.Repositories;
using StudentApi.DataModels;
using StudentApi.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSingleton<IStudentRepository,SqlStudentRepository>();
builder.Services.AddSingleton<StudentAdminContext>();
builder.Services.AddSingleton<IImageRepository,LocalStorageImageRepository>();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddDbContext<DbContext>();









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


