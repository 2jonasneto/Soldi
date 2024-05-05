using Microsoft.EntityFrameworkCore;
using Soldi.Application.Base;
using Soldi.Application.Commands;
using Soldi.Application.Handlers;
using Soldi.Core.Base;
using Soldi.Data.Base;
using Soldi.Web.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContext<SoldiDbContext>(options => options
.UseSqlServer(builder.Configuration.GetConnectionString("strcon")));
builder.Services.AddAutoMapper(typeof(DTOMapping).Assembly);

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICommandHandler<CartaoAdicionarCommand>, CartaoCommandHandler>();
builder.Services.AddScoped<ICommandHandler<CartaoAtualizarCommand>, CartaoCommandHandler>();
builder.Services.AddScoped<ICommandHandler<UsuarioAdicionarCommand>, UsuarioCommandHandler>();
builder.Services.AddScoped<ICommandHandler<UsuarioAtualizarCommand>, UsuarioCommandHandler>();
builder.Services.AddScoped<ICommandHandler<AlterarSenhaCommand>, UsuarioCommandHandler>();
builder.Services.AddScoped<ICartaoQueryHandler, CartaoQueryHandler>();
builder.Services.AddScoped<IUsuarioQueryHandler, UsuarioQueryHandler>(); var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
