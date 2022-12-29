using AHY.CQRS.Data;
using AHY.CQRS.WebApi.CQRS.Handlers;
using AHY.CQRS.WebApi.CQRS.Handlres;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(opt =>
{
    opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<StudentContext>(opt =>
{
    opt.UseSqlServer("server=(localdb)\\MSSQLLocalDb;database=StudentCQRSDb;integrated security=true;");
});
builder.Services.AddMediatR(typeof(Program));
builder.Services.AddScoped<GetStudentByIdQueryHandler>();
builder.Services.AddScoped<GetStudentsQueryHandler>();
builder.Services.AddScoped<CreateStudentCommandHandler>();
builder.Services.AddScoped<RemoveStudentCommandHandler>();
builder.Services.AddScoped<UpdateStudentCommandHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
