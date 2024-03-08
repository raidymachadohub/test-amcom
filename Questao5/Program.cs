using MediatR;
using Questao5.Infrastructure.Sqlite;
using System.Reflection;
using AutoMapper;
using Questao5.Domain.Mappings;
using Questao5.Infrastructure.Context;
using Questao5.Infrastructure.Repository;
using Questao5.Infrastructure.Repository.Interface;
using Questao5.Services;
using Questao5.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

// sqlite
builder.Services.AddSingleton(new DatabaseConfig { Name = builder.Configuration.GetValue<string>("DatabaseName", "Data Source=database.sqlite") });
builder.Services.AddSingleton<IDatabaseBootstrap, DatabaseBootstrap>();
builder.Services.AddEntityFrameworkSqlite().AddDbContext<Q5Context>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Repositry
builder.Services.AddScoped<IContaCorrenteRepository, ContaCorrenteRepository>();
builder.Services.AddScoped<IMovimentoRepository, MovimentoRepository>();
//builder.Services.AddScoped<IPotenciaRepository, PotenciaRepository>();

//Service

builder.Services.AddScoped<IMovimentoService, MovimentoService>();
builder.Services.AddScoped<IContaCorrenteService, ContaCorrenteService>();
//builder.Services.AddSingleton<IPotenciaRepository, PotenciaService>();

//mapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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

// sqlite
#pragma warning disable CS8602 // Dereference of a possibly null reference.
app.Services.GetService<IDatabaseBootstrap>().Setup();
#pragma warning restore CS8602 // Dereference of a possibly null reference.

app.Run();

// Informa��es �teis:
// Tipos do Sqlite - https://www.sqlite.org/datatype3.html


