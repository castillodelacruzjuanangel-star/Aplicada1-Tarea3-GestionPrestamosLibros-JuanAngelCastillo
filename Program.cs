<<<<<<< HEAD
using Microsoft.EntityFrameworkCore;
using RegistroPrestamosLibros.Components;
using RegistroPrestamosLibros.Context;
using RegistroPrestamosLibros.Services;
=======
using Context;
using Microsoft.EntityFrameworkCore;
using RegistroPrestamosLibros.Components;
using Services;
>>>>>>> b077bcd8b94ade1afe424741f764a76ebf130d9f

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var ConStr = builder.Configuration.GetConnectionString("ConStr");

builder.Services.AddDbContextFactory<Contexto>(o => o.UseSqlServer(ConStr));

builder.Services.AddScoped<EstudianteServices>();
builder.Services.AddScoped<LibroServices>();
<<<<<<< HEAD
builder.Services.AddScoped<PrestamoServices>();
=======
builder.Services.AddScoped<PrestamoLibroServices>();
>>>>>>> b077bcd8b94ade1afe424741f764a76ebf130d9f

builder.Services.AddBlazorBootstrap();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
