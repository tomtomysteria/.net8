# Documentation Technique - FirstProject

## Concepts Techniques

### Structure du Projet
Le projet est structuré autour de plusieurs démonstrations :
- **CalculatorDemo** : Exemple de calculs mathématiques.
- **PersonDemo** : Gestion des entités liées aux personnes.
- **AnimalDemo** : Gestion des entités liées aux animaux.
- **ProductDemo** : Gestion des produits.

### Points Clés
- Utilisation de classes statiques pour organiser les démonstrations.
- Application des principes de programmation orientée objet (héritage, encapsulation, polymorphisme).
- Utilisation des namespaces pour structurer le code.

### Commandes Utiles

#### Installation
- Restaurer les dépendances :
  ```bash
  dotnet restore
  ```

#### Compilation
- Compiler le projet :
  ```bash
  dotnet build
  ```

#### Exécution
- Exécuter le projet :
  ```bash
  dotnet run
  ```

#### Tests
Si des tests sont ajoutés, exécutez-les avec :
```bash
dotnet test
```

### Notes
- Assurez-vous que la version du SDK .NET correspond à celle spécifiée dans le fichier `global.json`.
- Pour désactiver la télémétrie, configurez la variable d'environnement `DOTNET_CLI_TELEMETRY_OPTOUT` sur `1`.

## Ressources
- [Documentation officielle .NET](https://learn.microsoft.com/dotnet/)
- [Guide de programmation C#](https://learn.microsoft.com/dotnet/csharp/)
