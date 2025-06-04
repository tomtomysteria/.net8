# Documentation Technique et Métier - Formation Project

## Concepts Techniques

### Structure du Projet

Le projet est structuré autour de deux sous-projets :

- **FirstProject** : Démonstrations de concepts de programmation orientée objet (POO) en C#.
- **ProductApi** : API REST pour la gestion des produits.

### Points Clés

#### FirstProject

- Utilisation de classes statiques pour organiser les démonstrations.
- Application des principes de POO : héritage, encapsulation, polymorphisme.
- Utilisation des namespaces pour structurer le code.

#### ProductApi

- Création d'une API REST avec ASP.NET Core.
- Utilisation de Swagger pour la documentation de l'API.
- Gestion des produits avec des opérations CRUD.

## Concepts Métier

### FirstProject

- **CalculatorDemo** : Exemple de calculs mathématiques.
- **PersonDemo** : Gestion des entités liées aux personnes (employés, étudiants).
- **AnimalDemo** : Gestion des entités liées aux animaux.
- **ProductDemo** : Gestion des produits.

### ProductApi

- Gestion des produits avec des propriétés comme le nom, le prix et la catégorie.
- Recherche de produits par catégorie ou par terme.
- Validation des données lors de la création ou de la mise à jour des produits.

## Commandes Utiles

### Installation

- Restaurer les dépendances :

  ```bash
  dotnet restore
  ```

### Compilation

- Compiler la solution :

  ```bash
  dotnet build
  ```

### Exécution

- À la racine des projets respectifs, exécutez la commande suivante pour les démarrer :

  ```bash
  dotnet run
  ```

- Pour démarrer en mode "watch" (rechargement automatique à chaque modification) :

  ```bash
  dotnet watch
  ```

### Tests

Si des tests sont ajoutés, exécutez-les avec :

```bash
dotnet test
```

## Ressources

- [Documentation officielle .NET](https://learn.microsoft.com/dotnet/)
- [Guide de programmation C#](https://learn.microsoft.com/dotnet/csharp/)
- [ASP.NET Core Documentation](https://learn.microsoft.com/aspnet/core/)
