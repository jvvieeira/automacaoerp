using AutomacaoERP.API.ApplicationServices.Concretes;
using AutomacaoERP.API.ApplicationServices.Interfaces;
using AutomacaoERP.API.Services.Concretes.ERP;
using AutomacaoERP.API.Services.Concretes.Zenvia;
using AutomacaoERP.API.Services.Interfaces.ERP;
using AutomacaoERP.API.Services.Interfaces.Zenvia;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IERPApplicationService, ERPApplicationService>();
builder.Services.AddScoped<IERPService, ERPService>();
builder.Services.AddScoped<IEncurtadorLinkApplicationService, EncurtadorLinkApplicationService>();
builder.Services.AddScoped<IEncurtadorLinkService, EncurtadorLinkService>();
builder.Services.AddScoped<IZenviaApplicationService, ZenviaApplicationService>();
builder.Services.AddScoped<IZenviaService, ZenviaService>();

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

