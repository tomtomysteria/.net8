# ProductApi Project

## Description

**ProductApi** est une API REST développée avec ASP.NET Core (.NET 8). Elle permet de gérer des produits via des opérations CRUD (Create, Read, Update, Delete). Ce projet est conçu pour illustrer les bonnes pratiques de développement d'API avec ASP.NET Core.

## Stack Technique

- **Langage** : C#
- **Framework** : .NET 8
- **API** : ASP.NET Core
- **IDE recommandé** : Visual Studio Code
- **Gestion des dépendances** : NuGet
- **Documentation API** : Swagger

## Prérequis

- .NET SDK 8.0.405 ou supérieur
- Windows 10 ou supérieur
- Vérifiez la version de .NET installée avec la commande suivante :

  ```bash
  dotnet --version
  ```

## Installation

1. Clonez le dépôt :

   ```bash
   git clone <url-du-repo>
   cd formation
   ```

2. Installez les dépendances pour **ProductApi** :

   ```bash
   dotnet restore
   ```

## Lancer le projet

Exécutez la commande suivante pour démarrer **ProductApi** :

```bash
dotnet run
```

Pour démarrer en mode "watch" (rechargement automatique à chaque modification) :

```bash
dotnet watch
```

L'API sera accessible par défaut à l'adresse suivante : `http://localhost:5000`.

## Documentation des API

### Swagger

La documentation Swagger est disponible à l'adresse suivante :
[http://localhost:5156/swagger/index.html](http://localhost:5156/swagger/index.html)

### GraphQL

L'interface GraphQL est accessible à l'adresse suivante :
[http://localhost:5156/graphql/](http://localhost:5156/graphql/)

## Documentation

Pour plus de détails sur les concepts techniques et métier, consultez le fichier [DOCS.md](DOCS.md).
