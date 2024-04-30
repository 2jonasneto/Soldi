
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Soldi.Application.Commands;
using Soldi.Application.DTO;
using Soldi.Application.Handlers;
using Soldi.Application.Queries;
using Soldi.Core.Base;
using Soldi.Data.Base;
using System.Numerics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<SoldiDbContext>(options => options
.UseSqlServer(builder.Configuration.GetConnectionString("strcon")));
builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICommandHandler<CartaoAdicionarCommand>,CartaoCommandHandler>();
builder.Services.AddScoped<ICommandHandler<CartaoAtualizarCommand>,CartaoCommandHandler>();
builder.Services.AddScoped<IQueryHandler<CartaoDTO>, CartaoQueryHandler>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

    app.UseSwagger();
    app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
