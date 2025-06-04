# Formation Project

## Description

Ce projet est une solution .NET 8 contenant deux sous-projets : **FirstProject** et **ProductApi**. Il est conçu pour démontrer des concepts avancés de programmation orientée objet en C# ainsi que la création d'une API REST avec ASP.NET Core.

## Stack Technique

- **Langage** : C#
- **Framework** : .NET 8
- **API** : ASP.NET Core
- **IDE recommandé** : Visual Studio Code
- **Gestion des dépendances** : NuGet

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

2. Installez les dépendances pour tous les projets :

   ```bash
   dotnet restore
   ```

## Lancer les projets

À la racine des projets respectifs, exécutez la commande suivante pour les démarrer :

```bash
dotnet run
```

Pour démarrer en mode "watch" (rechargement automatique à chaque modification) :

```bash
dotnet watch
```

## Documentation

Pour plus de détails sur les concepts techniques et métier, consultez le fichier [DOCS.md](DOCS.md).
