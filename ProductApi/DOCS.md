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

## Gestion des requêtes PATCH

Le projet prend en charge les requêtes HTTP PATCH pour permettre des mises à jour partielles des entités. Cela est implémenté dans le contrôleur `ProductsController` via l'action `PatchProduct`. Cette méthode utilise les bibliothèques `Microsoft.AspNetCore.JsonPatch` pour appliquer des modifications partielles à un produit existant et `Microsoft.AspNetCore.Mvc.NewtonsoftJson` pour gérer le support du formatage JSON.

### Fonctionnement

1. **Endpoint** : L'endpoint pour les requêtes PATCH est défini comme suit :

   ```csharp
   [HttpPatch("{id}")]
   public async Task<IActionResult> PatchProduct(int id, JsonPatchDocument<Product> patchDocument)
   ```

   - id : Identifiant du produit à mettre à jour.
   - patchDocument : Document JSON contenant les modifications à appliquer.

2. **Validation** :

   - Si le document de patch est null, une réponse 400 Bad Request est retournée.
   - Si le produit correspondant à l'id fourni n'est pas trouvé, une réponse 404 Not Found est retournée.

3. **Application des modifications** :

   - Les modifications sont appliquées au produit via la méthode ApplyTo de JsonPatchDocument.
   - Si le modèle résultant n'est pas valide, une réponse 400 Bad Request contenant les erreurs de validation est retournée.

4. **Sauvegarde** :

   - Une fois les modifications appliquées et validées, elles sont sauvegardées dans la base de données via SaveChangesAsync.

### Exemple de requête PATCH

Voici un exemple de requête PATCH pour mettre à jour le stock d'un produit :

```
PATCH /api/products/1
Content-Type: application/json

[
    { "op": "replace", "path": "/name", "value": "Nouveau nom du produit" },
    { "op": "replace", "path": "/price", "value": 99.99 }
]
```

### Réponse attendue

- 204 No Content : Si les modifications ont été appliquées avec succès.
- 400 Bad Request : Si le document de patch est invalide ou si les modifications entraînent des erreurs de validation.
- 404 Not Found : Si le produit avec l'id spécifié n'existe pas.

Cette approche permet une mise à jour flexible et ciblée des entités, tout en respectant les bonnes pratiques REST.

## Gestion de GraphQL

Le projet **ProductApi** intègre GraphQL pour permettre des interactions flexibles et performantes avec les données. Cette fonctionnalité est implémentée à l'aide de la bibliothèque **HotChocolate**.

### Fonctionnement de GraphQL

GraphQL est un langage de requête pour les API qui permet aux clients de demander uniquement les données dont ils ont besoin. Contrairement aux API REST traditionnelles, GraphQL offre une flexibilité accrue en permettant de composer des requêtes complexes en une seule interaction.

#### Points clés de l'implémentation dans ProductApi

1. **Configuration** :
   - GraphQL est configuré dans le fichier `Program.cs` via `AddGraphQLServer()`.
   - Les types `Query` et `Mutation` sont enregistrés pour gérer les requêtes et mutations respectivement.
   - Les fonctionnalités de filtrage, tri et projections sont activées via `AddFiltering()`, `AddSorting()` et `AddProjections()`.

   Exemple de configuration dans `Program.cs` :

   ```csharp
   builder.Services
       .AddGraphQLServer()
       .AddQueryType<Query>()
       .AddMutationType<Mutation>()
       .AddFiltering()
       .AddSorting()
       .AddProjections();
   ```

2. **Types GraphQL** :
   - **Query** : Définit les requêtes pour récupérer les données. Par exemple, la méthode `GetProducts` permet de récupérer les produits avec leurs détails.
   - **Mutation** : Définit les mutations pour modifier les données. Par exemple, la méthode `AddProduct` permet d'ajouter un nouveau produit.

3. **Injection de dépendances** :
   - Les services nécessaires, comme `ProductDbContext`, sont injectés dans les méthodes via l'attribut `[Service]`.

---

### Composer des requêtes GraphQL

#### Requête pour récupérer les produits (`query`)

Voici un exemple de requête pour récupérer les produits avec leurs détails :

```graphql
query {
  products {
    id
    name
    price
    stock
    category {
      name
    }
    tags {
      name
    }
    productDetail {
      description
      manufacturer
    }
  }
}

```

#### Résultat attendu

La requête ci-dessus retourne une liste de produits avec leurs informations détaillées. Exemple de réponse :

```json
{
  "data": {
    "products": [
      {
        "id": 1,
        "name": "Produit A",
        "price": 100,
        "stock": 50,
        "category": {
          "name": "Catégorie A"
        },
        "productDetail": {
          "description": "Description du produit A",
          "manufacturer": "Fabricant A"
        }
      },
      {
        "id": 2,
        "name": "Produit B",
        "price": 200,
        "stock": 30,
        "category": {
          "name": "Catégorie B"
        },
        "productDetail": {
          "description": "Description du produit B",
          "manufacturer": "Fabricant B"
        }
      }
    ]
  }
}
```

---

#### Requête pour récupérer un produit spécifique (`query`)

Voici un exemple de requête pour récupérer un produit spécifique avec ses détails :

```graphql
query {
  product(id: 15) {
    id
    name
    price
    stock
    category {
      name
    }
    tags {
      name
    }
    productDetail {
      description
      manufacturer
    }
  }
}
```

#### Résultat attendu

La requête ci-dessus retourne les informations détaillées du produit avec l'ID spécifié. Exemple de réponse :

```json
{
  "data": {
    "product": {
      "id": 15,
      "name": "Produit Modifié",
      "price": 200,
      "stock": 30,
      "category": {
        "name": "Catégorie B"
      },
      "tags": [
        {
          "name": "Tag 1"
        },
        {
          "name": "Tag 2"
        }
      ],
      "productDetail": {
        "description": "Description modifiée",
        "manufacturer": "Fabricant Y"
      }
    }
  }
}
```

---

#### Mutation pour ajouter un nouveau produit (`mutation`)

Voici un exemple de mutation pour ajouter un nouveau produit avec des tags associés :

```graphql
mutation {
  addProduct(
    productDto: {
      name: "Nouveau Produit"
      price: 150
      stock: 20
      categoryId: 1
      tagIds: [1, 3]
      productDetail: {
        description: "Description du nouveau produit"
        manufacturer: "Fabricant X"
      }
    }
  ) {
    id
    name
  }
}
```

#### Résultat attendu

La mutation ci-dessus ajoute un nouveau produit et retourne ses informations principales. Exemple de réponse :

```json
{
  "data": {
    "addProduct": {
      "id": 3,
      "name": "Nouveau Produit"
    }
  }
}
```

---

#### Mutation pour supprimer un produit (`mutation`)

Voici un exemple de mutation pour supprimer un produit existant :

```graphql
mutation {
  deleteProduct(id: 2)
}
```

#### Résultat attendu

La mutation ci-dessus supprime le produit avec l'ID spécifié. Exemple de réponse :

```json
{
  "data": {
    "deleteProduct": true
  }
}
```

---

### Avantages de GraphQL

1. **Flexibilité** : Les clients peuvent demander uniquement les données dont ils ont besoin.
2. **Performances** : Une seule requête peut récupérer des données complexes, réduisant ainsi le nombre d'appels réseau.
3. **Documentation interactive** : Avec des outils comme GraphQL Playground ou Banana Cake Pop, vous pouvez explorer et tester facilement votre API.

---

### Ressources supplémentaires

- [Documentation officielle GraphQL](https://graphql.org/)
- [Documentation HotChocolate](https://chillicream.com/docs/hotchocolate)
- [Explorer GraphQL avec Banana Cake Pop](https://chillicream.com/docs/bananacakepop)

## Ressources

- [Documentation officielle .NET](https://learn.microsoft.com/dotnet/)
- [Guide de programmation C#](https://learn.microsoft.com/dotnet/csharp/)
- [ASP.NET Core Documentation](https://learn.microsoft.com/aspnet/core/)
