# Documentation Technique et Métier - ProductApi

## Concepts Techniques

### Structure du Projet

Le projet **ProductApi** est structuré autour des principes suivants :

- **Controllers** : Gestion des endpoints API.
- **Models** : Définition des entités métier (exemple : `Product`).
- **Services** : Logique métier pour la gestion des produits.
- **Middleware** : Configuration des pipelines HTTP.

### Points Clés

- Utilisation de **Swagger** pour la documentation interactive de l'API.
- Validation des données avec des annotations (`[Required]`, `[Range]`, etc.).
- Gestion des erreurs avec des réponses HTTP standardisées.

## Concepts Métier

### Entité `Product`

L'entité `Product` représente un produit avec les propriétés suivantes :

- **Id** : Identifiant unique.
- **Name** : Nom du produit.
- **Price** : Prix du produit.
- **Category** : Catégorie du produit.

### Fonctionnalités

- **CRUD** : Création, lecture, mise à jour et suppression de produits.
- **Recherche** : Filtrage des produits par catégorie ou par nom.

## Commandes Utiles

### Installation

- Restaurer les dépendances :

  ```bash
  dotnet restore
  ```

### Compilation

- Compiler le projet :

  ```bash
  dotnet build
  ```

### Exécution

- Démarrer l'API :

  ```bash
  dotnet run
  ```

- Pour démarrer en mode "watch" (rechargement automatique à chaque modification) :

  ```bash
  dotnet watch
  ```

### Création d'un projet Web API

Pour créer un nouveau projet Web API avec .NET :

```bash
dotnet new webapi -n NomDuProjet
```

Remplacez `NomDuProjet` par le nom souhaité pour votre projet.

### Tests

Si des tests sont ajoutés, exécutez-les avec :

```bash
dotnet test
```

## Ressources

- [Documentation officielle .NET](https://learn.microsoft.com/dotnet/)
- [Guide de programmation C#](https://learn.microsoft.com/dotnet/csharp/)
- [ASP.NET Core Documentation](https://learn.microsoft.com/aspnet/core/)
