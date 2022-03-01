using FineManagement.Application;
using FineManagement.Application.Commands;
using FineManagement.Application.Mappers;
using FineManagement.Infrastructure;
using FineManagement.Infrastructure.Constants;
using FineManagement.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.LoadInfrastructureDependencies().AddSql(builder.Configuration);

builder.Services.LoadApplicationDependencies();

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
