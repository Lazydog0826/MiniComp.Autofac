using Microsoft.Extensions.DependencyInjection;

namespace MiniComp.Autofac;

[AttributeUsage(AttributeTargets.Class)]
public class AutofacDependencyAttribute(Type type) : Attribute
{
    public ServiceLifetime ServiceLifetime { get; set; } = ServiceLifetime.Scoped;

    public Type Type { get; set; } = type;

    public string ServiceKey { get; set; } = string.Empty;
}
