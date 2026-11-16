## Documentation – Start Here
This repository is designed to work alongside the Notion guide.

**Read the concepts first, then explore the code and experiment with it.**

**[Complete Dependency Injection Guide – Notion]**
(https://karamnotes.notion.site/Dependency-Injection-419814368e0c807db2d3dded093532b2?source=copy_link)

## What You'll Learn

- Services and Dependency Injection.
- Dependency Inversion Principle (DIP).
- Inversion of Control (IoC).
- Constructor Injection and View Injection.
- Transient, Scoped, and Singleton lifetimes.
- Service Scopes and Lifetime Management.
- DI Registration Methods.
- Dependency Injection Best Practices.
- Autofac Integration and Lifetime Scopes.

##  Technologies
- C#
- ASP.NET Core MVC
- Autofac
- Razor Views

##  Getting Started

Clone the repository:

```bash
git clone YOUR_REPOSITORY_LINK_HERE
```

Restore packages and run:

```bash
dotnet restore
dotnet run
```

Open the local URL displayed in the terminal.

## 🧪 Practice – Experiment with Service Lifetimes

Open `Program.cs` and find the Autofac registration section.

Try each lifetime separately:

| Lifetime | Autofac Registration | Built-in DI |
|---|---|---|
| Transient | `InstancePerDependency()` | `AddTransient()` |
| Scoped | `InstancePerLifetimeScope()` | `AddScoped()` |
| Singleton | `SingleInstance()` | `AddSingleton()` |

**Important:** Enable only one registration at a time.

### Observe the Results

The project generates a unique ID for every new `CitiesService` instance using:

```csharp
_serviceInstanceID = Guid.NewGuid();
```

Run the application and compare:

- Service Instance 1, 2, and 3.
- Instance from Scope.
- Instance from View.

Change the lifetime and refresh the page. Observe how the IDs change.

**Think about:**
- Why do some instances share the same ID?
- Why does a new Autofac Lifetime Scope create a different instance with Scoped registration?
- Why does Singleton keep the same instance?
- How does View Injection interact with the request scope?

## Autofac Lifetime Scope

Explore this code in `HomeController`:

```csharp
using (ILifetimeScope scope = _lifetimeScope.BeginLifetimeScope())
{
    ICitiesService citiesService =
        scope.Resolve<ICitiesService>();
}
```

Experiment with `BeginLifetimeScope()` and `Resolve<T>()` and observe how different lifetime registrations affect the resolved object.

📂Project Structure
```text
DIExample/
├── Controllers/
│   └── HomeController.cs
├── ServiceContracts/
│   └── ICitiesService.cs
├── Services/
│   └── CitiesService.cs
├── Views/
│   └── Home/
│       └── Index.cshtml
├── wwwroot/
│   └── css/
│       └── site.css
└── Program.cs
```

## Learning Tips
1. Read the related Notion topic first.
2. Find its implementation in the repository.
3. Predict the result before running the application.
4. Change the registration and observe the instance IDs.
5. Understand *why* the behavior changes instead of just copying the code.

## Final Goal
Understand how DI works in ASP.NET Core, how containers manage dependencies, and how different lifetimes affect object instances.

**Notion explains the concepts. This repository helps you practice them.**
