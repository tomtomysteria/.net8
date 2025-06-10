using Microsoft.EntityFrameworkCore;
using ProductApi.Data;
using ProductApi.GraphQL;
using ProductApi.GraphQL.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer(); // Ajoute les services nécessaires pour explorer les endpoints de l'application, utile pour la documentation OpenAPI/Swagger.
builder.Services.AddSwaggerGen(); // Configure Swagger pour générer automatiquement la documentation de l'API, permettant une interface interactive pour tester les endpoints.

builder.Services.AddControllers().AddNewtonsoftJson(); // Enregistre les services nécessaires pour les contrôleurs dans le conteneur d'injection de dépendances et ajoute le support pour le formatage JSON via Newtonsoft.
builder.Services.AddDbContext<ProductDbContext>(options => options.UseSqlite("Data Source=products.db")); // Configure le contexte de base de données ProductDbContext pour utiliser SQLite comme fournisseur, avec un fichier de base de données nommé 'products.db'.

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddTypeExtension<QueryTypeExtension>() // Ajout de l'extension
    .AddFiltering()
    .AddSorting()
    .AddProjections();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Décommenter la ligne suivante si HTTPS est nécessaire
// app.UseHttpsRedirection();

app.MapControllers(); // Configure les routes des contrôleurs dans le pipeline HTTP pour gérer les requêtes.
app.MapGraphQL(); // Ajout de l'endpoint GraphQL

await app.RunAsync();
