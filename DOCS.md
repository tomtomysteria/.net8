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

---

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

---

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

### Nettoyage

- Nettoyer le projet pour supprimer les fichiers temporaires et les artefacts de compilation :

  ```bash
  dotnet clean
  ```

### Tests

- Si des tests unitaires sont ajoutés, exécutez-les avec :

  ```bash
  dotnet test
  ```

### Gestion des packages

- Ajouter un package NuGet au projet :

  ```bash
  dotnet add package <NomDuPackage>
  ```

  Exemple pour ajouter **Newtonsoft.Json** :

  ```bash
  dotnet add package Newtonsoft.Json
  ```

- Lister les packages installés dans le projet :

  ```bash
  dotnet list package
  ```

- Supprimer un package NuGet du projet :

  ```bash
  dotnet remove package <NomDuPackage>
  ```

### Informations sur le projet

- Afficher les informations sur le projet :

  ```bash
  dotnet projectinfo
  ```

### Création de nouveaux projets

- Créer un projet console :

  ```bash
  dotnet new console -n NomDuProjet
  ```

- Créer un projet Web API :

  ```bash
  dotnet new webapi -n NomDuProjet
  ```

- Créer un projet de tests unitaires :

  ```bash
  dotnet new xunit -n NomDuProjet
  ```

### Gestion des migrations (Entity Framework Core)

- Ajouter une migration :

  ```bash
  dotnet ef migrations add <NomMigration>
  ```

- Appliquer les migrations à la base de données :

  ```bash
  dotnet ef database update
  ```

- Supprimer la dernière migration :

  ```bash
  dotnet ef migrations remove
  ```

- Affiche toutes les migrations appliquées ou disponibles :

  ```bash
  dotnet ef migrations list
  ```

Ces commandes couvrent les opérations courantes pour gérer un projet .NET, que ce soit pour ajouter des packages, exécuter des tests, ou gérer des bases de données avec Entity Framework Core.

---

## Descriptif des Namespaces

### **System**

- Namespace principal contenant les types fondamentaux et les fonctionnalités de base.
- **Exemples** :
  - **`System.String`** : Manipulation des chaînes de caractères.
  - **`System.Int32`** : Type pour les entiers.
  - **`System.IO`** : Gestion des entrées/sorties (fichiers, flux).
  - **`System.Net`** : Communication réseau.

### **Microsoft**

- Namespace utilisé pour les technologies développées par Microsoft.
- **Exemples** :
  - **`Microsoft.AspNetCore`** : Framework pour les applications web.
  - **`Microsoft.EntityFrameworkCore`** : ORM pour la gestion des bases de données.
  - **`Microsoft.Azure`** : Classes pour interagir avec les services Azure.

### **Windows**

- Namespace spécifique aux applications Windows.
- **Exemples** :
  - **`Windows.UI`** : Classes pour les interfaces utilisateur Windows.
  - **`Windows.Foundation`** : Classes pour les applications modernes.

### **Runtime**

- Namespace pour interagir avec le runtime .NET.
- **Exemples** :
  - **`Runtime.InteropServices`** : Interopérabilité avec du code natif.
  - **`Runtime.CompilerServices`** : Fonctionnalités avancées comme les attributs de compilation.

### **Newtonsoft**

- Namespace utilisé pour la bibliothèque JSON.NET, très populaire pour la manipulation de données JSON.
- **Exemples** :
  - **`Newtonsoft.Json`** : Sérialisation et désérialisation JSON.

### **System.Collections.Generic**

- Namespace pour les collections génériques.
- **Exemples** :
  - **`List<T>`** : Liste générique.
  - **`Dictionary<TKey, TValue>`** : Collection clé-valeur.

### **System.Linq**

- Namespace pour effectuer des requêtes sur des collections de données.
- **Exemples** :
  - **`Enumerable.Where`**, **`Select`**, **`OrderBy`** : Méthodes LINQ.

### **System.Threading.Tasks**

- Namespace pour la gestion des tâches asynchrones.
- **Exemples** :
  - **`Task`**, **`Task<T>`** : Gestion des opérations asynchrones.

### **System.Text**

- Namespace pour manipuler du texte et gérer les encodages.
- **Exemples** :
  - **`StringBuilder`** : Manipulation efficace des chaînes.
  - **`Encoding.UTF8`** : Gestion des encodages.

### **Swashbuckle.AspNetCore**

- Namespace utilisé pour intégrer Swagger dans les applications ASP.NET Core.
- **Exemples** :
  - **`SwaggerGen`** : Génération de la documentation Swagger.
  - **`SwaggerUI`** : Interface utilisateur pour interagir avec l'API.

---

## Ressources

- [Documentation officielle .NET](https://learn.microsoft.com/dotnet/)
- [Guide de programmation C#](https://learn.microsoft.com/dotnet/csharp/)
- [ASP.NET Core Documentation](https://learn.microsoft.com/aspnet/core/)
