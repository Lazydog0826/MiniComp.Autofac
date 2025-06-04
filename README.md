# MiniComp.Autofac

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Host.UseAutofac();
builder.Services.AutoAddDependency(ObjectExtension.GetProjectAllType());
```

```csharp
[AutofacDependency(typeof(IService), ServiceLifetime = ServiceLifetime.Scoped, ServiceKey = "")]
public class Service : IService { }
```

```csharp
[AutofacDependency(typeof(IFXService<>), ServiceLifetime = ServiceLifetime.Scoped, ServiceKey = "")]
public class FXService<T> : IFXService<T> where T : class { }
```
