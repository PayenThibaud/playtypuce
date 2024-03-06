using ExercicesCSharpASP.NET.Data;
using ExercicesCSharpASP.NET.Models;
using ExercicesCSharpASP.NET.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

var conn = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<AppDbContext>(option => option.UseSqlServer(conn));

builder.Services.AddScoped<IRepository<Contact>, ContactRepository>();

// ajouter le service IMapper de AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("allConnections", options =>
//    {
//        options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
//    });
//    options.AddPolicy("angularApp", options =>
//    {
//        options.WithOrigins("https://angularadress:angularport").WithMethods("GET").WithHeaders("application/json");
//    });
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// c'est ici que l'on va utiliser le middleware des cors (cross-origin requests)
// on le laisse vide lorsque l'on utilise des policy sur nos contrôlleurs/actions (ne pas oublier le service de configuration des cors)
// on peut aussi préciser une policy qui s'appliquera sur toute l'application avec son nom
//app.UseCors("allConnections");
// cette version permet d'appliquer une policy globale sans la nommer:
app.UseCors(options =>
{
    options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
});

app.UseAuthorization();

app.MapControllers();

app.Run();
