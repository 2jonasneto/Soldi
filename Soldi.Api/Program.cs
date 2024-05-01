
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Soldi.Application.Base;
using Soldi.Application.Commands;
using Soldi.Application.DTO;
using Soldi.Application.Handlers;
using Soldi.Application.Queries;
using Soldi.Core.Base;
using Soldi.Core.Entities;
using Soldi.Data.Base;
using System.Numerics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<SoldiDbContext>(options => options
.UseSqlServer(builder.Configuration.GetConnectionString("strcon")));
builder.Services.AddAutoMapper(typeof(DTOMapping).Assembly);

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICommandHandler<CartaoAdicionarCommand>,CartaoCommandHandler>();
builder.Services.AddScoped<ICommandHandler<CartaoAtualizarCommand>,CartaoCommandHandler>();
builder.Services.AddScoped<ICommandHandler<UsuarioAdicionarCommand>,UsuarioCommandHandler>();
builder.Services.AddScoped<ICommandHandler<UsuarioAtualizarCommand>,UsuarioCommandHandler>();
builder.Services.AddScoped<ICommandHandler<AlterarSenhaCommand>,UsuarioCommandHandler>();
builder.Services.AddScoped<ICartaoQueryHandler, CartaoQueryHandler>();
builder.Services.AddScoped<IUsuarioQueryHandler, UsuarioQueryHandler>();

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
